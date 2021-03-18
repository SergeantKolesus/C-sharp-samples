using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class WordClass
    {
        private string word;

        public string Word
        {
            get
            {
                return word;
            }
        }

        #region Override

        #region Operator override

        #region Strong comparison

        public static bool operator<(WordClass first, WordClass second)
        {
            int length = first.word.Length <= second.word.Length ? first.word.Length : second.word.Length;

            for (int i = 0; i < length; i++)
            {
                if (first.word.ElementAt(i) < second.word.ElementAt(i))
                    return true;

                if (first.word.ElementAt(i) > second.word.ElementAt(i))
                    return false;
            }

            if (length != second.word.Length)
                return true;

            return false;
        }

        public static bool operator>(WordClass first, WordClass second)
        {
            int length = first.word.Length <= second.word.Length ? first.word.Length : second.word.Length;

            for (int i = 0; i < length; i++)
            {
                if (first.word.ElementAt(i) < second.word.ElementAt(i))
                    return false;

                if (first.word.ElementAt(i) > second.word.ElementAt(i))
                    return true;
            }

            if ( (length == second.word.Length) && (length != first.word.Length))
                return true;

            return false;
        }

        #endregion Strong comparison

        #region Soft comparison

        public static bool operator <=(WordClass first, WordClass second)
        {
            int length = first.word.Length <= second.word.Length ? first.word.Length : second.word.Length;

            for (int i = 0; i < length; i++)
            {
                if (first.word.ElementAt(i) < second.word.ElementAt(i))
                    return true;

                if (first.word.ElementAt(i) > second.word.ElementAt(i))
                    return false;
            }

            if (length == first.word.Length)
                return true;

            return false;
        }

        public static bool operator >=(WordClass first, WordClass second)
        {
            int length = first.word.Length <= second.word.Length ? first.word.Length : second.word.Length;

            for (int i = 0; i < length; i++)
            {
                if (first.word.ElementAt(i) < second.word.ElementAt(i))
                    return false;

                if (first.word.ElementAt(i) > second.word.ElementAt(i))
                    return true;
            }

            if (length == second.word.Length)
                return true;

            return false;
        }

        #endregion Soft comparison

        #region Equality comparison

        public static bool operator ==(WordClass first, WordClass second)
        {
            if (first.word.Length != second.word.Length)
                return false;

            int length = first.word.Length;

            for (int i = 0; i < length; i++)
                if (first.word.ElementAt(i) != second.word.ElementAt(i))
                    return false;

            return true;
        }

        public static bool operator !=(WordClass first, WordClass second)
        {
            if (first.word.Length != second.word.Length)
                return true;

            int length = first.word.Length;

            for (int i = 0; i < length; i++)
                if (first.word.ElementAt(i) != second.word.ElementAt(i))
                    return true;

            return false;
        }

        #endregion Equality comparison

        #endregion Operator override
        /*
        public static bool Equals()
        {

        }
        */

        #endregion Override

        public WordClass(string value)
        {
            word = value.Substring(0);
        }
    }
}
