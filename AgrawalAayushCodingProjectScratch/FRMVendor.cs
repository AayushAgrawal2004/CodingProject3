using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using InventoryMaintenance;
using System.Runtime.Remoting.Contexts;
using static System.Net.Mime.MediaTypeNames;

namespace AgrawalAayushCodingProjectScratch
{
    public partial class FRMVendor : Form
    {
        public FRMVendor()
        {
            InitializeComponent();
        }
        //Global list variable to store vendors.
        List<Vendor> vendors = new List<Vendor>();
        //current list index
        int intCurrentVendorIndex = 0;
        //keep track if data has changed
        bool blnVendorChanged = false;

        /// <summary>
        /// Read vendors from the xml file
        /// Fill the listbox with the vendors
        /// Set the current index to be 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMVendor_Load(object sender, EventArgs e)
        {
            // Add a statement here that gets the list of items.
            vendors = VendorDB.GetVendors(); //reads vendors from XML file
            SetCurrentIndex(0); //passes 0 to the SetCurrentIndex method
        }

        /// <summary>
        /// Set the current index and fill the vendor data in the controls
        /// </summary>
        /// <param name="intIndex"></param>
        private void SetCurrentIndex(int intIndex)
        {
            intCurrentVendorIndex = intIndex; //assigns intCurrentIndex with intIndex parameter
            FillVendor(intIndex); //passes intIndex argument to FillVendor method
        }

        /// <summary>
        /// Fill vendor data in the controls from vendor list
        /// </summary>
        /// <param name="i"></param>
        private void FillVendor(int intIndex)
        {
            TXTName.Text = vendors[intIndex].Name; //assigns name textbox with n vendor's name
            TXTCity.Text = vendors[intIndex].City; //assigns city textbox with n vendor's city
            TXTState.Text = vendors[intIndex].State; //assigns state textbox with n vendor's state
            TXTStreetAddress.Text = vendors[intIndex].Address; //assigns street address textbox with n vendor's street address
            TXTZipCode.Text = vendors[intIndex].Zip; //assigns zip code textbox with n vendor's zip code
            TXTPhoneNumber.Text = vendors[intIndex].Phone; //assigns phone number textbox with n vendor's phone number
            TXTYTDSales.Text = vendors[intIndex].YTD.ToString(); //assigns sales YTD textbox with n vendor's sales YTD
            TXTComment.Text = vendors[intIndex].Comment; //assigns comment textbox with n vendor's comment
            TXTContact.Text = vendors[intIndex].Contact; //assigns contact textbox with n vendor's contact

            //assigns default discount variable with n vendor's default discount
            //selects item in combobox containing the three types of default discounts
            int intDefDiscount = vendors[intIndex].DefaultDiscount; 
            if (intDefDiscount == 10)
            {
                CBODefaultDiscount.SelectedIndex = 0;
            }
            else if (intDefDiscount == 15)
            {
                CBODefaultDiscount.SelectedIndex = 1;
            }
            else if (intDefDiscount == 20)
            {
                CBODefaultDiscount.SelectedIndex = 2;
            }
            DataReset(); //because loading first vendor details into textboxes causes textboxes to change, reset to where blnVendorChanged = false and vendor form is ready to be changed by user
        }

        /// <summary>
        /// Set the new index based on Next button. If last item already selected then set it to index 0 else current index + 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNNext_Click(object sender, EventArgs e)
        {
            if (IsSaveVendor()) //if IsSaveVendor returns true
            {
                if (intCurrentVendorIndex != vendors.Count - 1) //if intCurrentVendorIndex is not equal to the fifth index (the last vendor), display details of next vendor
                {
                    SetCurrentIndex(intCurrentVendorIndex + 1); //displays details of the next vendor on the form
                }
                else
                {
                    SetCurrentIndex(0); //if user goes to next vendor and is currently on the last vendor, the details for the first vendor will display
                }
            }
        }

        /// <summary>
        /// Set the new index based on Previous button. If the first item already selected then set it to index last item else current index - 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BTNPrevious_Click(object sender, EventArgs e)
        {
            if (IsSaveVendor()) //if IsSaveVendor returns true
            {
                if (intCurrentVendorIndex != 0) //if intCurrentVendorIndex is not equal to the first index (the first vendor), display details of next vendor
                {
                    SetCurrentIndex(intCurrentVendorIndex - 1); //displays details of the next vendor on the form
                }
                else
                {
                    SetCurrentIndex(vendors.Count - 1); //if user goes to next vendor and is currently on the first vendor, the details for the last vendor will display
                }
            }
        }

        /// <summary>
        /// Saves the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNSave_Click(object sender, EventArgs e)
        {
            //if the user changes the details for a vendor and presses the save button, SaveVendor validates the entries and text in the textboxes is assigned to associated property of the specific vendor
            if (blnVendorChanged)  
            {
                if (SaveVendor()) //validates the entries and text in the textboxes is assigned to associated property of the specific vendor
                {
                    DataReset(); //blnVendorChanged is set to false and asterisk is removed from the text of form 
                }
            }
        }

        /// <summary>
        /// Check if vendor has changed and save the vendor and then close the vendor form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNClose_Click(object sender, EventArgs e)
        {
           Close(); //Closes form 
        }

        /// <summary>
        /// If user has not saved the data, then cancel the closing of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMVendor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaveVendor()) //if IsSaveVendor returns false, cancel the closing of the form
            {
                e.Cancel = true; //cancels the closing of the form
            }
        }


        /// <summary>
        /// Check if vendor has changed and then ask the user if they would like to save the vendor, if yes, save the vendor
        /// </summary>
        /// <returns></returns>
        private bool IsSaveVendor()
        {
            if (blnVendorChanged) //if blnVendorChanged is true
            {
                // displays a dialog box to confirm
                string strMessage = "Vendor data has been changed. Do you want to save the data?";
                DialogResult btnMessage = MessageBox.Show(strMessage, "", MessageBoxButtons.YesNoCancel); //displays strMessage and three options in a dialog box

                //if user presses yes in the dialog box, entries are validated and entries in textboxes are assigned to specific vendor's property
                if (btnMessage == DialogResult.Yes)
                {
                    //save changes if valid data
                    if (SaveVendor()) //calls SaveVendor() method and if the entries are succesfully validated, returns true
                    {
                        return true; //if
                    }
                    else
                    {
                        return false; //if entries fail the validation, returns false
                    }
                }
                else if (btnMessage == DialogResult.No) //revert changes
                {
                    FillVendor(intCurrentVendorIndex); //revert to current vendor's details
                    return true; 
                }
                else
                {
                    //cancel option
                    return false;
                }
            }
            else //if data is not changed
            {
                return true;
            }
        }

        /// <summary>
        /// Save the vendor data if all data are valid
        /// </summary>
        private bool SaveVendor()
        {
            if (IsValidData()) //check if data is valid
            {
                try
                {
                    //assigns new vendor information to associated property within the vendor list
                    vendors[intCurrentVendorIndex].Name = TXTName.Text;
                    vendors[intCurrentVendorIndex].Address = TXTStreetAddress.Text;
                    vendors[intCurrentVendorIndex].City = TXTCity.Text;
                    vendors[intCurrentVendorIndex].State = TXTState.Text;
                    vendors[intCurrentVendorIndex].Zip = TXTZipCode.Text;
                    vendors[intCurrentVendorIndex].Phone = TXTPhoneNumber.Text;
                    vendors[intCurrentVendorIndex].YTD = Convert.ToDecimal(TXTYTDSales.Text);
                    vendors[intCurrentVendorIndex].Comment = TXTComment.Text;
                    vendors[intCurrentVendorIndex].Contact = TXTContact.Text;
                    if (CBODefaultDiscount.SelectedIndex == 0)
                    {
                        vendors[intCurrentVendorIndex].DefaultDiscount = 10;
                    }
                    else if (CBODefaultDiscount.SelectedIndex == 1)
                    {
                        vendors[intCurrentVendorIndex].DefaultDiscount = 15;
                    }
                    else if (CBODefaultDiscount.SelectedIndex == 2)
                    {
                        vendors[intCurrentVendorIndex].DefaultDiscount = 20;
                    }
                    
                    //saves vendor list to XML file and displays successfil save message
                    VendorDB.SaveVendors(vendors);
                    MessageBox.Show("Data has been saved successfully!");
                    return true;
                }
                catch (FormatException) //triggered if user inputs a non-numeric value 
                {
                    MessageBox.Show("Format error. Please enter a numeric value.", "Entry Error");
                    return false;
                }

                //specific catch block
                catch (OverflowException) //triggered if user inputs too large values
                {
                    MessageBox.Show("Overflow error. Please enter smaller numbers.", "Entry Error");
                    return false;
                }

                //generic catch block
                //catches any other type of error that the programmer is not anticipating
                //displays error message, type of error, and stack trace
                catch
                {
                    MessageBox.Show("Data error. Please fix the issue!","Entry Error");
                    return false;
                }
            }
            else
            {
                return false; //returns false if the data could not be successfully validated
            }
        }

        #region Save Changed Data (Venders*)
        /// <summary>
        /// If name changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTName_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTStreetAddress_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTCity_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTState_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTZipCode_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// check if phone number changed
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// check if YTD Sale has changed
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTYTDSales_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// check if comment has changed
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTComment_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// Check if contact changed
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTContact_TextChanged(object sender, EventArgs e)
        {
            DataChanged();
        }

        /// <summary>
        /// Check if Default Discount changed
        /// If the data changed, set the new data in the vendors list and set the record to be saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBODefaultDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataChanged();
        }
        #endregion

        /// <summary>
        /// Data has changed, set boolean variable to true and enable save button
        /// </summary>
        private void DataChanged()
        {
            //if user changes text in textbox, blnVendorChanged is set to true and text for form has an asterisk at the end to signal to user that textbox has been changed
            blnVendorChanged = true; 
            this.Text = "Vendors*";
        }

        /// <summary>
        /// reset the form data
        /// </summary>
        private void DataReset()
        {
            //After the data is saved, blnVendorChanged is set to false and the asterisk from the text of the form is removed
            blnVendorChanged = false;
            this.Text = "Vendors";
        }

        #region Validation
        /// <summary>
        /// Validating all data before saving
        /// </summary>
        /// <returns></returns>
        private bool IsValidData()
        {
            string strErrorMessage = "";
            strErrorMessage += Validator.IsVendorName(TXTName.Text, TXTName.Tag.ToString()); //name is letters
            strErrorMessage += Validator.IsStreetAddress(TXTStreetAddress.Text, TXTStreetAddress.Tag.ToString()); //street address
            strErrorMessage += Validator.IsCharacters(TXTCity.Text, TXTCity.Tag.ToString()); //city is letters
            strErrorMessage += Validator.IsCharacters(TXTState.Text, TXTState.Tag.ToString()); //state is letters

            //nned to update logic to include military zip code (EX: APO 77840)
            strErrorMessage += Validator.IsZipCode(TXTZipCode.Text, TXTZipCode.Tag.ToString()); //zip address
            //strErrorMessage += Validator.IsInteger(TXTZipCode.Text, TXTZipCode.Tag.ToString()); //zip is integer
            //strErrorMessage += Validator.IsLength(TXTZipCode.Text, TXTZipCode.Tag.ToString(), 5); //zipcode (be 5 characters long)
            
            strErrorMessage += Validator.IsPhoneNumber(TXTPhoneNumber.Text, TXTPhoneNumber.Tag.ToString()); //phone numbers
            strErrorMessage += Validator.IsDecimal(TXTYTDSales.Text, TXTYTDSales.Tag.ToString()); //YTD is a valid decimal
            strErrorMessage += Validator.IsCharacters(TXTContact.Text, TXTContact.Tag.ToString()); //contact
            strErrorMessage += Validator.IsSelectedDefaultDiscount(CBODefaultDiscount.SelectedIndex, CBODefaultDiscount.Tag.ToString());

            //determines if there is an error & if there is, OUTPUTS the messagebox with error msg & names it entry error
            if (strErrorMessage != "")
            {
                MessageBox.Show(strErrorMessage, "Validation Error");
                TXTName.Focus();
                return false; //false bc there is an error
            }
            return true;
        }
        #endregion
    }
}
