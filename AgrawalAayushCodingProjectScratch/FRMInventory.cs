using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgrawalAayushCodingProjectScratch
{
    public partial class FRMInventory : Form
    {
        public FRMInventory()
        {
            InitializeComponent();
        }

        //two-dimensional array of ingredients
        string[,] strIngredientsQty =        { {"Flour", "200" },
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

        /// <summary>
        /// Closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads ingredients into listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMInventory_Load(object sender, EventArgs e)
        {
            LBXInventory.Items.Clear();
            for (int i = 0; i < strIngredientsQty.GetLength(0); i++)
            {
                LBXInventory.Items.Add(strIngredientsQty[i, 0] + "\t\t\t" + strIngredientsQty[i, 1]);
            }
        }

        /// <summary>
        /// update the inventory
        /// </summary>
        /// <param name="strUpdatedInventory"></param>
        public void UpdateInventory(string[,] strUpdatedInventory) //strUpdatedInventory parameter receives passed argument from order form
        {
            //set current inventory
            strIngredientsQty = strUpdatedInventory; //assigns value of parameter to str
        }
    }
}
