using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public enum ColorEn
    {
        black = 0,
        red = 1
    }

    class RBTreeNode
    {
        private uint count;
        private WordClass value;

        ColorEn nodeColor;

        public RBTreeNode leftSon;
        public RBTreeNode rigthSon;
        public RBTreeNode father;

        public WordClass Value
        {
            get
            {
                return value;
            }
        }

        public uint Count
        {
            get
            {
                return count;
            }
        }

        public string Color
        {
            get
            {
                if(nodeColor == 0)
                    return "Black";

                return "Red";
            }
        }

        public ColorEn ColorType
        {
            get
            {
                return nodeColor;
            }
        }


        public void IncreaseCount()
        {
            count++;
        }

        public RBTreeNode(string word = "")
        {
            count = 1;
            nodeColor = 0;
            value = new WordClass(word);
            leftSon = null;
            rigthSon = null;
            father = null;
        }

        public void Recolor()
        {
            nodeColor = 1 - nodeColor;
        }

        public bool IsLeaf()
        {
            return (leftSon == null) && (rigthSon == null);
        }
    }

    class RBTree
    {
        RBTreeNode root;

        public RBTree()
        {
            root = null;
        }

        public RBTreeNode Root
        {
            get
            {
                return root;
            }
        }

        private void _checkRoot()
        {
            while (root.father != null)
                root = root.father;
        }

        #region Add node

        private RBTreeNode _getUncle(RBTreeNode node)
        {
            if (node.father.father.leftSon == node.father)
                return node.father.father.rigthSon;

            return node.father.father.leftSon;
        }

        private bool _inline(RBTreeNode node)
        {
            return ((node.father.leftSon == node) && (node.father.father.leftSon == node.father))
                || ((node.father.rigthSon == node) && (node.father.father.rigthSon == node.father));
        }

        private void _smallLeftTurn(RBTreeNode node)
        {
            RBTreeNode temp = node.father;

            if (node.father == node.father.father.leftSon)
                node.father.father.leftSon = node;
            else
                node.father.father.rigthSon = node;

            node.father = node.father.father;
            temp.rigthSon = node.leftSon;
            if(node.leftSon != null)
                node.leftSon.father = temp;
            temp.father = node;
            node.leftSon = temp;
        }

        private void _smallRigthTurn(RBTreeNode node)
        {
            RBTreeNode temp = node.father;
            
            if(node.father == node.father.father.leftSon)
                node.father.father.leftSon = node;
            else
                node.father.father.rigthSon = node;


            node.father = node.father.father;
            temp.leftSon = node.rigthSon;
            if(node.rigthSon != null)
                node.rigthSon.father = temp;
            temp.father = node;
            node.rigthSon = temp;
        }

        private void _bigLeftTurn(RBTreeNode node)
        {
            RBTreeNode temp = node.father.father;

            if (node.father.father.father != null)
            {
                if (node.father.father == node.father.father.father.leftSon)
                    node.father.father.father.leftSon = node.father;
                else
                    node.father.father.father.rigthSon = node.father;

                node.father.father = temp.father;
            }
            else
            {
                node.father.father = null;
            }

            temp.rigthSon = node.father.leftSon;
            
            if(node.father.leftSon != null)
                node.father.leftSon.father = temp;
            temp.father = node.father;
            node.father.leftSon = temp;
            temp.Recolor();
            node.father.Recolor();
        }

        private void _bigRigthTurn(RBTreeNode node)
        {
            RBTreeNode temp = node.father.father;

            if (node.father.father.father != null)
            {
                if (node.father.father == node.father.father.father.leftSon)
                    node.father.father.father.leftSon = node.father;
                else
                    node.father.father.father.rigthSon = node.father;

                node.father.father = temp.father;
            }
            else
            {
                node.father.father = null;
            }

            temp.leftSon = node.father.rigthSon;

            if (node.father.rigthSon != null)
                node.father.rigthSon.father = temp;
            temp.father = node.father;
            node.father.rigthSon = temp;
            temp.Recolor();
            node.father.Recolor();
        }

        private void _rebalance(RBTreeNode node)
        {
            if (node.father == null)
            {
                if (node.ColorType == ColorEn.red)
                    node.Recolor();
                return;
            }

            if (node.father.ColorType == ColorEn.black)
                return;

            if (node.father.father == null)
                return;

            if ( (node.father.ColorType == ColorEn.red) && (_getUncle(node) != null) && (_getUncle(node).ColorType == ColorEn.red) )
            {
                node.father.father.Recolor();
                node.father.Recolor();
                _getUncle(node).Recolor();

                _rebalance(node.father.father);

                return;
            }

            if(!_inline(node))
            {
                if (node.father.leftSon == node)
                {
                    _smallRigthTurn(node);
                    _bigLeftTurn(node.rigthSon);    
                }
                else
                {
                    _smallLeftTurn(node);
                    _bigRigthTurn(node.leftSon);
                }

                return;
            }

            if ( ((_getUncle(node) == null) || (_getUncle(node).ColorType == ColorEn.black) ) && _inline(node))
            {
                if (node.father.leftSon == node)
                    _bigRigthTurn(node);
                else
                    _bigLeftTurn(node);
            }
        }
            

        public void AddNode(RBTreeNode node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                RBTreeNode subroot = root;

                while (subroot != null)
                {
                    if (node.Value < subroot.Value)
                    {
                        if (subroot.leftSon == null)
                        {
                            subroot.leftSon = node;
                            node.father = subroot;
                            if (node.ColorType == 0)
                                node.Recolor();
                            break;
                        }

                        subroot = subroot.leftSon;
                    }

                    if (node.Value > subroot.Value)
                    {
                        if (subroot.rigthSon == null)
                        {
                            subroot.rigthSon = node;
                            node.father = subroot;
                            if (node.ColorType == 0)
                                node.Recolor();
                            break;
                        }

                        subroot = subroot.rigthSon;
                    }

                    if (node.Value == subroot.Value)
                    {
                        subroot.IncreaseCount();
                        return;
                    }
                }

                _rebalance(node);

                while (root.father != null)
                    root = root.father;
            }
        }

        #endregion Add node

        #region Delete node

        private void _blackRecolor(RBTreeNode node, bool brotherLeft)
        {
            if (node == root)
                return;

            if(node.ColorType == ColorEn.red)
            {
                node.Recolor();
                node.father.Recolor();
                if (brotherLeft)
                    _smallRigthTurn(node);
                else
                    _smallLeftTurn(node);
            }
            else
            {
                if( ( (node.leftSon == null) || (node.leftSon.ColorType == ColorEn.black) ) && 
                    ((node.rigthSon == null) || (node.rigthSon.ColorType == ColorEn.black)) )
                {
                    node.Recolor();
                    if (node.father.ColorType == ColorEn.red)
                        node.father.Recolor();
                    if(node.father.father.leftSon == node.father)
                        _blackRecolor(node.father.father.rigthSon, false);
                    else
                        _blackRecolor(node.father.father.leftSon, false);
                        
                    return;
                }
                else
                {
                    if( (node.rigthSon == null) || (node.rigthSon.ColorType == ColorEn.black) )
                    {
                        node.Recolor();
                        node.leftSon.Recolor();
                        _smallLeftTurn(node.leftSon);
                    }
                    else
                    {
                        if (node.father.ColorType != node.ColorType)
                            node.Recolor();

                        if (node.father.ColorType == ColorEn.red)
                            node.father.Recolor();

                        node.rigthSon.Recolor();
                        _smallRigthTurn(node);
                    }
                }
            }
        }

        public void DeleteNode(RBTreeNode node)
        {
            if(node == root)
            {
                if ((node.leftSon == null) && (node.rigthSon == null))
                {
                    root = null;
                    node.father = null;
                    return;
                }

                if (node.leftSon == null)
                {
                    root = node.rigthSon;
                    root.father = null;
                    root.Recolor();
                    return;
                }

                if (node.rigthSon == null)
                {
                    root = node.leftSon;
                    root.father = null;
                    Root.Recolor();
                    return;
                }
            }

            RBTreeNode temp;
            RBTreeNode temp2;
            RBTreeNode brother;
            bool brotherLeft = false;

            if( (node.leftSon != null) && (node.rigthSon != null) )
            {
                temp = node.leftSon;

                while (temp.rigthSon != null)
                    temp = temp.rigthSon;

                temp2 = node.leftSon;
                node.leftSon = temp.leftSon;
                temp.leftSon = temp2;

                if(node.leftSon != null)
                    node.leftSon.father = node;
                temp.leftSon.father = temp;

                temp2 = node.rigthSon;
                node.rigthSon = temp.rigthSon;
                temp.rigthSon = temp2;

                //node.rigthSon.father = node;
                temp.rigthSon.father = temp;

                
                if (temp.father.leftSon == temp)
                    temp.father.leftSon = node;
                else
                    temp.father.rigthSon = node;

                if(node.father != null)
                {
                    if (node.father.leftSon == node)
                        node.father.leftSon = temp;
                    else
                        node.father.rigthSon = temp;
                }

                temp2 = node.father;
                node.father = temp.father;
                temp.father = temp2;
                _checkRoot();

                if(node.ColorType != temp.ColorType)
                {
                    node.Recolor();
                    temp.Recolor();
                }
            }

            if( (node.rigthSon == null) && (node.leftSon == null) )
            {
                if (node.father.rigthSon == node)
                {
                    node.father.rigthSon = null;
                    brother = node.father.leftSon;
                    brotherLeft = true;
                }
                else
                {
                    node.father.leftSon = null;
                    brother = node.father.rigthSon;
                }

                node.father = null;
            }
            else
            {
                RBTreeNode son;

                if (node.rigthSon != null)
                    son = node.rigthSon;
                else
                    son = node.leftSon;

                if (node.father.rigthSon == node)
                {
                    node.father.rigthSon = son;
                    brother = node.father.leftSon;
                    brotherLeft = true;
                }
                else
                {
                    node.father.leftSon = son;
                    brother = node.father.rigthSon;
                }

                son.father = node.father;
                node.father = null;

                if ( (node.ColorType == ColorEn.black) && (son.ColorType == ColorEn.red) )
                {
                    son.Recolor();
                    return;
                }
            }

            if (node.ColorType == ColorEn.black)
                _blackRecolor(brother, brotherLeft);

            /*
            if ((node.rigthSon == null) && (node.leftSon == null))
            {
                temp = node.father;

                if (node.father == null)
                {
                    Unroot();
                    return;
                }

                if (node.father.rigthSon == node)
                    brother = node.father.leftSon;
                else
                    brother = node.father.rigthSon;

                if (node.father.leftSon == node)
                {
                    node.father.leftSon = null;
                    if (node.ColorType == ColorEn.black)
                    {
                        
                        _blackRecolor(brother);
                    }
                }
                else
                {
                    node.father.rigthSon = null;
                    if (node.ColorType == ColorEn.black)
                    {
                        _blackRecolor(brother);
                    }
                }

                

                    return;
            }

            if ( ( (node.rigthSon == null) && (node.leftSon != null) ) || ( (node.rigthSon != null) && (node.leftSon == null) ) )
            {
                if (node.father.leftSon == node)
                {
                    if (node.leftSon != null)
                    {
                        temp = node.leftSon;
                        node.father.leftSon = node.leftSon;
                        node.leftSon.father = node.father;
                    }
                    else
                    {
                        temp = node.rigthSon;
                        node.father.leftSon = node.rigthSon;
                        node.rigthSon.father = node.father;
                    }
                    //node.father.leftSon = null;
                    // if (node.ColorType == ColorEn.black)
                    //   _rebalance(temp.rigthSon);
                }
                else
                {
                    if (node.leftSon != null)
                    {
                        temp = node.leftSon;
                        node.father.rigthSon = node.leftSon;
                        node.leftSon.father = node.father;
                    }
                    else
                    {
                        temp = node.rigthSon;
                        node.father.rigthSon = node.rigthSon;
                        node.rigthSon.father = node.father;
                    }
                    //node.father.rigthSon = null;
                    //if (node.ColorType == ColorEn.black)
                    //   _rebalance(temp.leftSon);
                }

                if (node.father.leftSon == node)
                    brother = node.father.rigthSon;
                else
                    brother = node.father.leftSon;

                if(node.ColorType == ColorEn.black)
                {
                    if (temp.ColorType == ColorEn.red)
                        temp.Recolor();
                    else
                    {
                        _blackRecolor(brother);
                    }
                }

                return;
            }

            temp = node.leftSon;

            while( (temp.leftSon != null) || (temp.rigthSon != null) )
            {
                if (temp.rigthSon != null)
                    temp = temp.rigthSon;
                else
                    temp = temp.leftSon;
            }

            bool left;

            temp2 = temp.father;

            if (temp.father.leftSon == temp)
                left = true;
            else
                left = false;

            temp.father = node.father;

            if (node.father != null)
            {
                if (node.father.leftSon == node)
                    node.father.leftSon = temp;
                else
                    node.father.rigthSon = temp;
            }

            temp.leftSon = node.leftSon;
            temp.rigthSon = node.rigthSon;

            temp.leftSon.father = temp;
            temp.rigthSon.father = temp;

            node.leftSon = null;
            node.rigthSon = null;

            if (left)
                temp2.leftSon = node;
            else
                temp2.rigthSon = node;

            node.father = temp2;

            if(node.ColorType != temp.ColorType)
            {
                node.Recolor();
                temp.Recolor();
            }

            _checkRoot();

            DeleteNode(node);
            */

        }

        #endregion Delete node

        public void Unroot()
        {
            root = null;
        }
    }
}
