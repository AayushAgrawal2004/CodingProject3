using InventoryMaintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

//Our group (ALL OF US) completed our student evaluations!
//AUTHOR: Aayush Agrawal, Omar Hajyounes, Abby Moore, Tyrone Huang
//COURSE: ISTM 250.501
//FORM: FRMOrder.cs
//PURPOSE: Create an order form to collect and record customer and order info.
//INPUT: Customer info from (TXTName, TXTStreetAddress, TXTCity, TXTState, TXTZip, TXTPhoneNumber, TXTSubdivison) and order info from (CBXItem, CBXBreadOrCrust,
//TXTQuanity) ALSO delivery info is the same as what is entered for customer info
//UNLESS changed mannually
//PROCESS: CHKDelivery_CheckedChanged- if delivery checkbox is checked, delivery detail groupbox is enabled and all of the customer details is copied and pasted into delivery details,
//CHKCarryout_CheckedChanged-prevents both the delivery and carryout checboxes from being checked,
//FRMCodingProjectScratch_Load- when the form loads, the food item combo box is loaded with the food items from the strItems array ,
//CBXItem_SelectedIndexChanged- loads bread and crust options depending on which food item selected,
//TXTQuantity_TextChanged- collects quantity input & calculates subtotal,
//BTNAdd_Click- the bread or crust option, the selected food item, quantity, the price of the selected food item, and the subtotal are concatenated,
//BTNProcess_Click- find total cost & displays in txtbox,
//BTNClose_Click-closes form.
//OUTPUT: TXTSubtotal displays subtotal, LBXItemList order info , TXTTotalCost calculates total cost.
//HONOR CODE: “On my honor, as an Aggie, I have neither given nor received unauthorized aid on this academic work.”

namespace AgrawalAayushCodingProjectScratch
{
    public partial class FRMOrder : Form
    {
        public FRMOrder()
        {
            InitializeComponent();
        }

        #region global variables
        //class variables
        //everytime order is added or everything is cleared, quantity and the selectedindex for the food item goes back to zero
        //this prevents us from having to intialize multiple selected index variables for each specific event handler
        int intQuantity = 0;
        int intSelectedIndex = 0;
        //list to keep track of order items
        List<int[]> lstOrderItems= new List<int[]>();
        //ingredient inventory array
        string[,] strIngredients =        { {"Flour", "200" },
                                            {"Yeast", "50" },
                                            {"Sugar", "30" },
                                            {"Oil", "25" },
                                            {"Ham", "10" },
                                            {"Turkey", "10" },
                                            {"Scheese", "20" },
                                            {"Lettuce", "14" },
                                            {"Tomato", "14" },
                                            {"Bacon", "10" },
                                            {"Pickles", "20" },
                                            {"Mayo", "15" },
                                            {"Mustard", "12" },
                                            {"Pepprni", "20" },
                                            {"Sauce", "60" },
                                            {"Gcheese", "25" },
                                            {"Salt", "10" },
                                            {"Pepper", "10" } };
        //ingredients consumption array
        string[,] strIngredientConsumption = { {"Flour", "1", "1", "1", "3", "3", "3" },
                                               {"Yeast", "0.5", "0.5", "0.5", "2", "2", "2" },
                                               {"Sugar", "0.03", "0.03", "0.03", "0.5", "0.5", "0.5" },
                                               {"Oil", "0.05", "0.05", "0.05", "0.1", "0.1", "0.1" },
                                               {"Ham", "0.1", "0", "0", "0", "0", "0.1" },
                                               {"Turkey", "0", "0.1", "0", "0", "0", "0.1" },
                                               {"Scheese", "0.1", "0.1", "0", "0", "0", "0" },
                                               {"Lettuce", "0.25", "0.25", "0.3", "0", "0", "0" },
                                               {"Tomato", "0.25", "0.25", "0.3", "0", "0", "0.3" },
                                               {"Bacon", "0", "0", "0.1", "0" , "0", "0.1" },
                                               {"Pickles", "0.02", "0.02", "0", "0", "0", "0" },
                                               {"Mayo", "0.02", "0.02", "0.02", "0", "0", "0" },
                                               {"Mustard", "0.02", "0.02", "0.02", "0", "0", "0" },
                                               {"Pepprni", "0", "0", "0", "0", "0.3", "0.3" },
                                               {"Sauce", "0", "0", "0", "1", "1", "1" },
                                               {"Gcheese", "0", "0", "0", "0.3", "0.2", "0.2" },
                                               {"Salt", "0.01", "0.01", "0.01", "0.02", "0.02", "0.02" },
                                               {"Pepper", "0.01", "0.01", "0.01", "0.02", "0.02", "0.02" } };
        #endregion

        #region Order form 
        /// <summary>
        /// When the form loads, the food item combo box is loaded with the food items from the strItems array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMCodingProjectScratch_Load(object sender, EventArgs e)
        {
            //loads the comboboxes
            string[] strItems = { "Select a food item", "Ham & Swiss sandwhich", "Turkey & Provolone sandwich", "BLT sandwich", "Med. cheese pizza", "Med. pepperoni pizza", "Med. supreme pizza" };

            //loads the food options (items) into item combobox
            foreach (string strItem in strItems)
            {
                CBXItem.Items.Add(strItem);
            }

            //The selected index of the CBXItem combobox is set to zero
            CBXItem.SelectedIndex = 0;

            //delivery details groupbox is not enabled
            GBXDeliveryDetails.Enabled = false;
            BTNAdd.Enabled = false;

            //load customer default info
            SetDefaultCustomer();
        }

        /// <summary>
        /// assigns default info to customer textboxes
        /// </summary>
        private void SetDefaultCustomer()
        {
            TXTName.Text = "John Smith";
            TXTStreetAddress.Text = "123 Main Street";
            TXTCity.Text = "College Station";
            TXTState.Text = "TX";
            TXTZipCode.Text = "77845";
            TXTPhoneNumber.Text = "999-999-9999";
            TXTSubdivision.Text = "Subdivision";
        }

        /// <summary>
        /// if carryout checked, delivery groupbox is not accessible 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RDOCarryout_CheckedChanged(object sender, EventArgs e)
        {
            if (RDOCarryout.Checked)
            {
                //if delivery checkbox is not checked, the delivery detail groupbox is not enabled
                GBXDeliveryDetails.Enabled = false;

                //clears delivery details (in case)
                TXTDeliveryName.Clear();
                TXTDeliveryStreetAddress.Clear();
                TXTDeliveryCity.Clear();
                TXTDeliveryState.Clear();
                TXTDeliveryZipCode.Clear();
                TXTDeliveryPhoneNumber.Clear();
                TXTDeliverySubdivision.Clear();
                TXTName.Focus();
            }
        }

        /// <summary>
        /// if delivery button selected, delivery groupbox is accessible & customer details are copied over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RDODelivery_CheckedChanged(object sender, EventArgs e)
        {
            //if delivery checkbox is checked, all customer details is copied to delivery details
            if (RDODelivery.Checked)
            {
                GBXDeliveryDetails.Enabled = true;

                //All of the customer details is copied and pasted into delivery details
                TXTDeliveryName.Text = TXTName.Text.Trim();
                TXTDeliveryStreetAddress.Text = TXTStreetAddress.Text.Trim();
                TXTDeliveryCity.Text = TXTCity.Text.Trim();
                TXTDeliveryState.Text = TXTState.Text.Trim();
                TXTDeliveryZipCode.Text = TXTZipCode.Text.Trim();
                TXTDeliveryPhoneNumber.Text = TXTPhoneNumber.Text.Trim();
                TXTDeliverySubdivision.Text = TXTSubdivision.Text.Trim();

                //focuses on the delivery name textbox and allows user to tab and change the delivery details
                TXTDeliveryName.Focus();
            }
            else
            {
                //if delivery checkbox is not checked, the delivery detail groupbox is not enabled
                GBXDeliveryDetails.Enabled = false;

                //clears delivery details
                TXTDeliveryName.Clear();
                TXTDeliveryStreetAddress.Clear();
                TXTDeliveryCity.Clear();
                TXTDeliveryState.Clear();
                TXTDeliveryZipCode.Clear();
                TXTDeliveryPhoneNumber.Clear();
                TXTDeliverySubdivision.Clear();
                TXTName.Focus();
            }
        }

        /// <summary>
        /// If the user selects one of the sandwich options, the bread options are loaded into the BreadOrCrust combo box
        /// If the user selects one of the pizza options, the crust options are loaded into the BreadOrCrust combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void CBXItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedIndex equals to the selected index of the food option, which will be used in our if-statement logic
            intSelectedIndex = CBXItem.SelectedIndex;

            //Sandwich item selected... bread options loaded          
            //clearing quanity & subtotal
            intQuantity = 0; //resets class variable to 0 (code behind the scenes)
            TXTQuantity.Clear();

            if (intSelectedIndex == 1 || intSelectedIndex == 2 || intSelectedIndex == 3)//if sandwich item is chosen:
            {
                //the bread options are visible
                CBXBreadOrCrust.Enabled = true;

                //image of deli is displayed
                PBXPizzaImage.Visible = false;
                PBXDeliImage.Visible = true;

                //load bread options for sandwhich items
                string[] strBreadOptions = { "Select an option", "White", "Pumpernickel", "Rye", "Sourdough", "Multigrain" };

                //bread options are loaded into BreadOrCrust combo box
                CBXBreadOrCrust.Items.Clear();
                foreach (string strBreadOption in strBreadOptions)
                {
                    CBXBreadOrCrust.Items.Add(strBreadOption);
                }

                //start at the first index of the combo box, displays "Select an option"
                CBXBreadOrCrust.SelectedIndex = 0;
            }
            
            //Pizza selected... crust options loaded
            else if (intSelectedIndex == 4 || intSelectedIndex == 5 || intSelectedIndex == 6)//if pizza item is chosen:
            {
                //crust options are enabled and user can enter a quantity
                //bread options are not available
                CBXBreadOrCrust.Enabled = true;

                //image of pizza is displayed
                PBXDeliImage.Visible = false;
                PBXPizzaImage.Visible = true;

                //load crust options for pizza items
                string[] strCrustOptions = { "Select an option", "Original", "Pan", "Thin", "Wheat" };

                //crust options are loaded into BreadOrCrust combo box
                CBXBreadOrCrust.Items.Clear();
                foreach (string strCrustOption in strCrustOptions)
                {
                    CBXBreadOrCrust.Items.Add(strCrustOption);
                }

                //start at the first index of the combo box, displays "Select an option"
                CBXBreadOrCrust.SelectedIndex = 0;
            }

            //if the user hasnt selected neither of the options
            else
            {
                //quanity, subtotal, & breadOrcrust all disabled
                TXTQuantity.Enabled = false;
                CBXBreadOrCrust.Items.Clear();
                CBXBreadOrCrust.Enabled = false;

                //images are not visible
                PBXPizzaImage.Visible = false;
                PBXDeliImage.Visible = false;
                BTNAdd.Enabled = false;
            }
        }

        /// <summary>
        /// activate quantity and subtotal when breadcrust is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBXBreadOrCrust_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if user selects an index from the CBXBreadOrcrust combo box that is greater than 0, the quantity and subtotal textboxes are enabled and visible to the user
            if (CBXBreadOrCrust.SelectedIndex > 0)
            {
                TXTQuantity.Enabled = true;
                TXTQuantity.Focus();
            }
            else
            {
                TXTQuantity.Clear();
                TXTQuantity.Enabled = false;
                BTNAdd.Enabled = false;
            }
        }

        /// <summary>
        /// Check if quantity is ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if quantity is empty, intQuantity is zero
                if (TXTQuantity.Text == "")
                {
                    intQuantity = 0;
                }
                else //if there is a value entered in txtbox:
                {
                    if (IsValidOrderItem())
                    {
                        intQuantity = Convert.ToInt32(TXTQuantity.Text.Trim());
                        BTNAdd.Enabled = true;
                    }
                    else
                    {
                        TXTQuantity.Text = "";
                        TXTQuantity.Focus();
                        BTNAdd.Enabled = false;
                    }
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Enter a valid quanity value.", "Entry Error");
                TXTQuantity.Text = "";
                TXTQuantity.Focus();
                BTNAdd.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Enter valid whole number for quantity.", "Entry Error");
                TXTQuantity.Text = "";
                TXTQuantity.Focus();
                BTNAdd.Enabled = false;
            }
        }

        /// <summary>
        /// If the user selects one of the sandwich options, the bread options are loaded into the Bread/Crust combobox
        /// If the user selects one of the pizza options, the crust options are loaded into the Bread/Crust combobox
        /// When the user presses the add button, the bread or crust option, the selected food item, quantity, the price of the selected food item, and the subtotal are concatenated into one string and then added to the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNAdd_Click(object sender, EventArgs e)
        {
            //converts the selected food item to string and assigns to strSelectedItem
            if (IsValidOrderItem())
            {
                string strSelectedItem = CBXItem.SelectedItem.ToString();
                string strSubtotal = "";

                //initalized the string variable for the selected bread and crust options 
                string strSelectedBread = "";
                string strSelectedCrust = "";

                // add the ordered item in the list
                AddItem();
                CalculateTotalCost();

                //this is item subtotal for the listbox entry
                strSubtotal = CalculateItemTotal();

                //CONCATENATES the order info into one variable to be outputted in the listbox:
                //sandwich
                if (intSelectedIndex == 1 || intSelectedIndex == 2 || intSelectedIndex == 3) //if user selects one of the sandwhich options
                {

                    if (CBXBreadOrCrust.SelectedIndex == 1 || CBXBreadOrCrust.SelectedIndex == 2 || CBXBreadOrCrust.SelectedIndex == 3 || CBXBreadOrCrust.SelectedIndex == 4 || CBXBreadOrCrust.SelectedIndex == 5)
                    {
                        //the selected bread option is put into strSelectedBread
                        //The selected bread, selected item, quantity, and the subtotal is combined & added to listbox
                        strSelectedBread = CBXBreadOrCrust.SelectedItem.ToString();
                        LBXItemList.Items.Add(strSelectedBread + " " + strSelectedItem + ", " + intQuantity + "@$5.00, total: " + strSubtotal);                        
                    }
                }
                //pizza
                else if (intSelectedIndex == 4 || intSelectedIndex == 5 || intSelectedIndex == 6) //if user selects one of the pizza options
                {
                    //then depending on the bread option selected...
                    if (CBXBreadOrCrust.SelectedIndex == 1 || CBXBreadOrCrust.SelectedIndex == 2 || CBXBreadOrCrust.SelectedIndex == 3 || CBXBreadOrCrust.SelectedIndex == 4)
                    {
                        //the selected crust option is put into strSelectedCrust
                        //The selected crust, selected item, quantity, and the subtotal is cmobined & added to listbox
                        strSelectedCrust = CBXBreadOrCrust.SelectedItem.ToString();
                        LBXItemList.Items.Add(strSelectedCrust + " " + strSelectedItem + ", " + intQuantity + "@$9.50, total: " + strSubtotal);
                    }
                }
                //resets the items
                CBXItem.SelectedIndex = 0;
                BTNAdd.Enabled = false;
            }
        }

        /// <summary>
        /// Add item in the array
        /// </summary>
        private void AddItem()
        {
            // Add item no and quantity in the array
            int[] intItem = new int[2];
            //item no
            intItem[0] = CBXItem.SelectedIndex;
            //quantity
            intItem[1] = intQuantity;
            //add to the list
            lstOrderItems.Add(intItem);
        }

        /// <summary>
        /// Calculate subtotal and final total for the order
        /// </summary>
        private void CalculateTotalCost()
        {
            //initialized variables to be used:
            decimal decCombinedSubtotals = 0m; 
            //loop all items in the list
            foreach (int[] intItem in lstOrderItems)
            {
                //if item type is sandwich then price is $5
                if (intItem[0] == 1 || intItem[0] == 2 || intItem[0] == 3)
                {
                    decCombinedSubtotals = decCombinedSubtotals + (intItem[1] * 5.0m);
                }
                //if item type is pizza then price is $9.50
                else if (intItem[0] == 4 || intItem[0] == 5 || intItem[0] == 6)
                {
                    decCombinedSubtotals = decCombinedSubtotals + (intItem[1] * 9.50m);
                }
            }

            //set the subtotal
            TXTSubtotal.Text = decCombinedSubtotals.ToString("c");

            //Calculates the total cost WITH tax
            decimal decTotalCost = decCombinedSubtotals * 1.0825m; //combined subtotal is multiplied by the tax
            TXTTotal.Text = decTotalCost.ToString("c");
        }

        /// <summary>
        ///add all of the subtotals of the items in the listbox
        ///multiply the total of the subtotals with the tax, which is 8.25%
        ///display the final total in the total textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNProcess_Click(object sender, EventArgs e)
        {
            if (IsValidOrder())
            {
                MessageBox.Show("Thank you for your order! Your total is " + TXTTotal.Text + ".", "Order Completion");
                //update inventory for the order at the order processing
                CalculateInventory();
                //clear the controls and variables after processing the order
                Clear();
            }
            
            //reload default customer details
            SetDefaultCustomer();
        }
      
        /// <summary>
        /// clear the controls
        /// </summary>
        private void Clear()
        {
            //Clears out customer details
            TXTName.Clear();
            TXTStreetAddress.Clear();
            TXTCity.Clear();
            TXTState.Clear();
            TXTZipCode.Clear();
            TXTPhoneNumber.Clear();
            TXTSubdivision.Clear();

            //Clears out delivery details
            TXTDeliveryName.Clear();
            TXTDeliveryStreetAddress.Clear();
            TXTDeliveryCity.Clear();
            TXTDeliveryState.Clear();
            TXTDeliveryZipCode.Clear();
            TXTDeliveryPhoneNumber.Clear();
            TXTDeliverySubdivision.Clear();

            //both checboxes are reset
            RDOCarryout.Checked = true;
            RDODelivery.Checked = false;

            //quantity and subtotal textbox is cleared

            //listbox is cleared
            LBXItemList.Items.Clear();
            CBXBreadOrCrust.Items.Clear();
            //resets the items
            CBXItem.SelectedIndex = 0;
            //pizza and deli image are not visible
            PBXPizzaImage.Visible = false;
            PBXDeliImage.Visible = false;

            TXTQuantity.Clear();
            BTNAdd.Enabled = false;
            TXTSubtotal.Clear();

            //clears total txtbox
            TXTTotal.Clear();

            //quantity and intSelectedIndex class variables are reset to 0
            intQuantity = 0;
            intSelectedIndex = 0;

            //clear the order item array
            lstOrderItems.Clear();

            //reload default customer info
            SetDefaultCustomer();
        }

        /// <summary>
        /// Clears all text fields when user presses clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNClear_Click(object sender, EventArgs e)
        {
            //clear the controls and variables after clear button is pressed
            Clear();
        }
        
        /// <summary>
        /// Closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNClose_Click(object sender, EventArgs e)
        {
           Close(); //closes form
        }
        
        /// <summary>
        /// calculate subtotal based on different options and quantity
        /// </summary>
        private string CalculateItemTotal()
        {
            decimal decSubtotal = 0m;

            //if user selects one of the sandwich options, quantity is multiplied by $5 price
            if (intSelectedIndex == 1 || intSelectedIndex == 2 || intSelectedIndex == 3)
            {
                decSubtotal = intQuantity * 5;
            }
            //if user selects one of the pizza options, quantity is multiplied by $9.50 price
            else if (intSelectedIndex == 4 || intSelectedIndex == 5 || intSelectedIndex == 6)
            {
                decSubtotal = intQuantity * 9.50m;
            }

            //outputs to subtotal txtbox
            return decSubtotal.ToString("c");
        }
#endregion 

        #region Validation


        /// <summary>
        /// we are validating if the city and state are correct BEFORE processing IF user changed txt
        /// </summary>
        /// <returns></returns>
        private bool IsValidOrder()
        {
            string strErrorMessage = "";
            //customer infomation 
            strErrorMessage += Validator.IsCharacters(TXTName.Text, TXTName.Tag.ToString()); //name (be letters)
            strErrorMessage += Validator.IsStreetAddress(TXTStreetAddress.Text, TXTStreetAddress.Tag.ToString()); //street address
            strErrorMessage += Validator.IsCharacters(TXTCity.Text, TXTCity.Tag.ToString()); //city (be leters)
            strErrorMessage += Validator.IsCharacters(TXTState.Text, TXTState.Tag.ToString()); //state (be letters)
            strErrorMessage += Validator.IsInteger(TXTZipCode.Text, TXTZipCode.Tag.ToString()); //zipcode (be integer)
            strErrorMessage += Validator.IsLength(TXTZipCode.Text, TXTZipCode.Tag.ToString(), 5); //zipcode (be 5 characters long)
            strErrorMessage += Validator.IsPhoneNumber(TXTPhoneNumber.Text, TXTPhoneNumber.Tag.ToString()); //phone number
            strErrorMessage += Validator.IsCharacters(TXTSubdivision.Text, TXTSubdivision.Tag.ToString()); //subdivision (be letters)

            //delivery check
            if (RDODelivery.Checked)
            {
                //validates the city and state is correct
                strErrorMessage += Validator.IsCharacters(TXTDeliveryName.Text, TXTDeliveryName.Tag.ToString()); //name be letters
                strErrorMessage += Validator.IsStreetAddress(TXTDeliveryStreetAddress.Text, TXTDeliveryStreetAddress.Tag.ToString()); // stree address
                strErrorMessage += Validator.IsCharacters(TXTDeliveryCity.Text, TXTDeliveryCity.Tag.ToString()); //city be letters
                strErrorMessage += Validator.IsCharacters(TXTDeliveryState.Text, TXTDeliveryState.Tag.ToString()); //state be letters
                strErrorMessage += Validator.IsInteger(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString()); //zip code be integer
                strErrorMessage += Validator.IsLength(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString(), 5); //zipcode (be 5 characters long)
                strErrorMessage += Validator.IsPhoneNumber(TXTDeliveryPhoneNumber.Text, TXTDeliveryPhoneNumber.Tag.ToString()); // phone number
                strErrorMessage += Validator.IsCharacters(TXTDeliverySubdivision.Text, TXTDeliverySubdivision.Tag.ToString()); // subdivision

                strErrorMessage += Validator.IsCorrectCityState(TXTDeliveryCity.Text, TXTDeliveryState.Text, TXTDeliveryCity.Tag.ToString(), TXTDeliveryState.Tag.ToString());
            }


            if (LBXItemList.Items.Count == 0)
            {
                strErrorMessage += "Enter at least one order item\n";
            }

            //determines if there is an error & if there is, OUTPUTS the messagebox with error msg & names it entry error
            if (strErrorMessage != "")
            {
                MessageBox.Show(strErrorMessage, "Delivery Error");
                return false; //false bc there is an error
            }
            return true;
        }

        /// <summary>
        /// validate options during Add items in the listbox
        /// validate that name, other options and quantity
        /// </summary>
        /// <returns></returns>
        private bool IsValidOrderItem()
        {
            string strErrorMessage = "";

            //customer name
            //strErrorMessage += Validator.IsCharacters(TXTName.Text, TXTName.Tag.ToString());

            //item
            strErrorMessage += Validator.IsSelectedIndex(CBXItem.SelectedIndex, CBXItem.Tag.ToString());

            //crust/bread type
            strErrorMessage += Validator.IsSelectedIndex(CBXBreadOrCrust.SelectedIndex, CBXBreadOrCrust.Tag.ToString());

            //quanity
            strErrorMessage += Validator.IsPresent(TXTQuantity.Text, TXTQuantity.Tag.ToString());

            if (TXTQuantity.Text != "")
            {
                strErrorMessage += Validator.IsInteger(TXTQuantity.Text, TXTQuantity.Tag.ToString());
                strErrorMessage += Validator.IsWithinRange(TXTQuantity.Text, TXTQuantity.Tag.ToString(), 1, 100);
            }
            //determines if there is an error & if there is, OUTPUTS the messagebox with error msg & names it entry error
            if (strErrorMessage != "")
            {
                MessageBox.Show(strErrorMessage, "Input Error");
                return false; //false bc there is an error
            }
            return true;
        }
        #endregion

        #region Inventory logic
        /// <summary>
        /// Update inventory array based on items ordered and quantity of each item
        /// </summary>
        private void CalculateInventory()
        {
            //loop all items in the list
            foreach (int[] intItem in lstOrderItems)
            {
                //item current inventory
                int k = 1;
                //go through all the ingredients (rows)
                for (int i = 0; i < strIngredients.GetLength(0); i++)
                {
                    //convert inventory to decimal
                    decimal intInv = Convert.ToDecimal(strIngredients[i, k]);
                    //get how much inventory is consumed for the selected item
                    decimal intCons = Convert.ToDecimal(strIngredientConsumption[i, intItem[0]]);
                    //determine final inventory based on how many ingredients have been consumed
                    decimal intFinalInv = intInv - intCons * intItem[1];
                    //Update the array with the final inventory
                    strIngredients[i, k] = intFinalInv.ToString();
                }
            }
        }

        /// <summary>
        /// When user clicks on the inventory button, FRMInventory form is displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNInventory_Click(object sender, EventArgs e)
        {
            //define new inventory form
            FRMInventory InventoryForm = new FRMInventory(); //new instance of form
            //update the inventory in the inventory form
            InventoryForm.UpdateInventory(strIngredients); //pass the updated strIngredients form with the deductions to the UpdateInventory method of FRMInventory
            //display inventory form
            DialogResult result = InventoryForm.ShowDialog();
        }
        #endregion

        private void BTNVendors_Click(object sender, EventArgs e)
        {
            //define new vendor form
            FRMVendor VendorForm = new FRMVendor(); //new instance of form
            //display vendor form
            DialogResult result = VendorForm.ShowDialog();
        }
    }
}
