// Dice Simulation
// Samuel Tollefson
// POS/409
// April 6, 2015
// Jon Jensen

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dice_Simulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Tell the user about the program.
            MessageBox.Show("This program simulates the rolling of two dice 100 times." 
                + Environment.NewLine
                + Environment.NewLine
                + "Whenever the two dice display the same number, " 
                + "the program will show the roll sequence number and the number on the dice.");
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(); // Initiate a random object.
            int dice1 = 0; // Variable to hold the value of the first dice.
            int dice2 = 0; // Variable to hold the value of the second dice.
            int inaRow = 0; // Variable to hold the number of sequential double rolls.

            lstResults.Items.Clear(); // Clear the list
            
            // Count up to 100 in increments of 1.
            for (int sequence = 1; sequence <= 100; sequence ++)
            {
                dice1 = rnd.Next(1, 7); // Create a number between 1 and 6.
                dice2 = rnd.Next(1, 7); // Create a number between 1 and 6.
                if (dice1 == dice2) // Compare the numbers.
                {
                    inaRow = inaRow + 1; // Increment sequential double rolls.

                    // Display the rolls that produced doubles.
                    lstResults.Items.Add("Roll " + sequence + " produced a pair of " + dice1 + "s");

                    // This if statement was added because the following else statement displays the sequential doubles 
                    // only after the sequential doubles are finished. If the doubles end on the final roll,
                    // there is no other roll to display the number of doubles rolled.
                    if (inaRow > 1 & sequence == 100)
                    {
                        // Display the number of sequential double rolls.
                        lstResults.Items.Add("Nice, " + inaRow + " in a row");
                    }
                }
                else
                {
                    // Check to see if doubles have been rolled at least twice in a row.
                    if (inaRow > 1)
                    {
                        // Display the number of sequential double rolls.
                        lstResults.Items.Add("Nice, " + inaRow + " in a row");
                    }
                    inaRow = 0; // If doubles are not rolled, reset the variable.
                }
            }
        }
    }
}
