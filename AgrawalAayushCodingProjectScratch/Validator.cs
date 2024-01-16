using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InventoryMaintenance
{
    public static class Validator
    {

        public static string IsPresent(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
            }
            return strMessage;
        }


        public static string IsInteger(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
                return strMessage;
            }
            else
            {
                if (!Int32.TryParse(strTestValue, out _))
                {
                    strMessage += strControlName + " must be a valid integer value.\n";
                }
                return strMessage;
            }
        }

        public static string IsDecimal(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
                return strMessage;
            }
            else
            {
                if (!Decimal.TryParse(strTestValue, out _))
                {
                    strMessage += strControlName + " must be a valid decimal value.\n";
                }
                return strMessage;
            }              
        }

        public static string IsWithinRange(string strTestValue, string strControlName, decimal decMin, decimal decMax)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber < decMin || decTestNumber > decMax)
            {
                strMessage += strControlName + " must be between " + decMin + " and " + decMax + ".\n";
            }
            return strMessage;
        }

        public static string IsGreaterThan(string strTestValue, string strControlName, decimal decMin)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber <= decMin)
            {
                strMessage += strControlName + " must be greater than " + decMin + ".\n";
            }
            return strMessage;
        }

        public static string IsLessThan(string strTestValue, string strControlName, decimal decMax)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber >= decMax || decTestNumber > decMax)
            {
                strMessage += strControlName + " must be less than " + decMax + ".\n";
            }
            return strMessage;
        }

        public static string IsCharacters(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "") //IsPresent w/in IsCharacters... FIRST determines if there is smth present at all
            {
                strMessage = strControlName + " is a required field. \n";
                return strMessage;
            }
            else //if smth present, NEXT chcks if there are characters present
            {
                foreach (char c in strTestValue) //'c' is the variable of the strWordOrPhrase stripped down into letter-by-letter format
                {
                    if (!(char.IsLetter(c) || c == ' ')) //if the characters are NOT letters... then:
                    {
                        strMessage = strControlName + " must only include letters. \n";
                    }
                }
                return strMessage;
            }
        }

        
        public static string IsVendorName(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "") //IsPresent w/in IsCharacters... FIRST determines if there is smth present at all
            {
                strMessage = strControlName + " is a required field. \n";
                return strMessage;
            }
            else //if smth present, NEXT chcks if there are characters present
            {
                foreach (char c in strTestValue) //'c' is the variable of the strWordOrPhrase stripped down into letter-by-letter format
                {
                    if (!(char.IsLetter(c) || c == ' ' || c == '.')) //if the characters are NOT letters... then:
                    {
                        strMessage = strControlName + " must only include letters. \n";
                    }
                }
                return strMessage;
            }
        }

        public static string IsLength(string strTestValue, string strControlName, int intLength)
        {
            string strMessage = "";
            if (strTestValue.Trim().Length != intLength)
            {
                strMessage = strControlName + " must be " + intLength + " characters long. \n";
            }
            return strMessage;
        }

        public static string IsSelectedIndex(int intTestValue, string strControlName)
        {
            string strMessage = "";
            if (intTestValue <= 0)
            {
                strMessage = strControlName + " is a required field. Please select a food item." + "\n";
            }
            return strMessage;
        }

        public static string IsSelectedDefaultDiscount(int intTestValue, string strControlName)
        {
            string strMessage = "";
            if (intTestValue < 0)
            {
                strMessage = strControlName + " is a required field." + "\n";
            }
            return strMessage;
        }

        public static string IsCorrectCityState(string strCity, string strState, string strControlNameCity, string strControlNameState)
        {
            string strMessage = "";
            
            //IsPresent validation
            if (strCity.Trim() == "") //if no city is enterd return:
            {
                strMessage += strControlNameCity + " is a required field \n";
            }
            if (strState.Trim() == "") //if no state is enterd return:
            {
                strMessage += strControlNameState + " is a required field \n";
            }
            else //if info is entered for BOTH city/state then:
            {
                string strWrongCityMessage = ""; //string message for wrong city
                string strWrongStateMessage = "";//string message for wrong state

                if (strState.Trim().ToLower() != "tx" && strState.Trim().ToLower() != "texas") //if they have entered the wrong state
                {
                    strWrongStateMessage = strControlNameState + " must be Texas or TX.\n";
                }
                if (strCity.Trim().ToLower() != "bryan" && strCity.Trim().ToLower() != "college station") //if they have entered the wrong city:
                {
                    strWrongCityMessage = strControlNameCity + " must be either Bryan or College Station.\n";
                }

                if(strWrongCityMessage != "" || strWrongStateMessage != "")
                {
                    //if either state, city OR BOTH are incorrect, the output:
                    strMessage = "Delivery is not possible.\n" + strWrongCityMessage + strWrongStateMessage;
                }
            }
            return strMessage;
        }
        /// <summary>
        /// validate phone number
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public static string IsPhoneNumber(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
            }
            else
            {
                if (strTestValue.Trim().Length == 10 || strTestValue.Trim().Length == 9 || strTestValue.Trim().Length == 12)
                {
                    if (!(Int64.TryParse(strTestValue, out _)))
                    {
                        String[] str1 = strTestValue.Split('-');
                        if (str1.Length == 3)
                        {
                            if (!(IsInt(str1[0]) && IsInt(str1[1]) && IsInt(str1[2])))
                            {
                                strMessage += strControlName + " must be a valid phone number.\n";
                            }
                        }
                        else
                        {
                            strMessage += strControlName + " must be a valid phone number.\n";
                        }
                    }
                }
                else
                {
                    strMessage += strControlName + " must be a valid phone number.\n";
                }
            }
            return strMessage;
        }

        /// <summary>
        /// validate street address
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public static string IsStreetAddress(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
            }
            else
            {
                String[] str1 = strTestValue.Trim().Split(' ');
                if (str1.Length > 1)
                {
                    if (!(IsInt(str1[0]) && IsLetters(str1[1])))
                    {
                        strMessage += strControlName + " must be a valid street address.\n";
                    }
                }
                else
                {
                    strMessage += strControlName + " must be a valid street address.\n";
                }
            }
            return strMessage;
        }


        public static string IsZipCode(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
            }
            else
            {
                String[] str1 = strTestValue.Trim().Split(' ');
                if (str1.Length > 1)
                {
                    //if (!(IsInt(str1[1]) && IsLetters(str1[0])))
                    //{
                    //    strMessage += strControlName + " must be a valid zip code.\n";
                    //}
                    if (!(IsInt(str1[1]) && str1[0] == "APO"))
                    {
                        strMessage += strControlName + " must be a valid zip code.\n";
                    }
                }
                else
                {
                    strMessage += IsInteger(strTestValue, strControlName);
                    strMessage += IsLength(strTestValue, strControlName,5);
                }
            }
            return strMessage;
        }

        /// <summary>
        /// returns true if string only contains numbers
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <returns></returns>
        public static bool IsInt(string strTestValue)
        {
            if (!Int32.TryParse(strTestValue, out _))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// return true if string has letters only
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <returns></returns>
        public static bool IsLetters(string strTestValue)
        {
            bool blnResult = true;
            foreach (char c in strTestValue) //'c' is the variable of the strWordOrPhrase stripped down into letter-by-letter format
            {
                if (!char.IsLetter(c)) //if the characters are NOT letters... then:
                {
                    blnResult = false;
                }
            }
            return blnResult;
        }
    }
}
