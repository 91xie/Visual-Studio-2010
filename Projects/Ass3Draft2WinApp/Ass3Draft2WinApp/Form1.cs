using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ass3Draft2WinApp
{
    public partial class Form1 : Form
    {
        
        static List<Valve> ListOfValves = new List<Valve>();
        
        static bool serialcreate, statuscreate, typecreate, subtypecreate;
        static bool serialedit;
        static int EditValveIndex;
        static VariableFlowValve var_vcopy;
        public Form1()
        {
            InitializeComponent();
            checkBox1Constant.Click += new EventHandler(checkBox1Constant_Click);
            checkBox2Variable.Click += new EventHandler(checkBox2Variable_Click);
            checkBox3On.Click += new EventHandler(checkBox3On_Click);
            checkBoxOff.Click += new EventHandler(checkBoxOff_Click);
            button1Create.Click += new EventHandler(button1Create_Click);
            button1SerialCheck.Click += new EventHandler(button1SerialCheck_Click);
            checkBoxEditOn.Click += new EventHandler(checkBoxEditOn_Click);
            checkBoxEditOff.Click += new EventHandler(checkBoxEditOff_Click);
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);
            buttonSerialLoad.Click += new EventHandler(buttonSerialLoad_Click);
            buttonEditUp.Click += new EventHandler(buttonEditUp_Click);
            buttonEditDown.Click += new EventHandler(buttonEditDown_Click);
            buttonEditandSave.Click += new EventHandler(buttonEditandSave_Click);
            
            
        }
        //<EDIT AND SAVE BUTTON>
        //after pressing the load button, this edit and save button appears and all of the necessary changes/info have been inputted into form.
        void buttonEditandSave_Click(object sender, EventArgs e)
        {
            
            //ListOfValves[EditValveIndex] that was loaded. where editindexvalve is the position index of the valve which was loaded.
            
            if (checkBoxEditOn.Checked == true)
            { ListOfValves[EditValveIndex].TurnOn(); }
            else if (checkBoxEditOn.Checked == false)
            { ListOfValves[EditValveIndex].TurnOff(); }

            //spits out editted valve with changes
            labelEditSaveOutput.Visible = true;
            labelEditSaveOutput.Text = ListOfValves[EditValveIndex].ToString();
            
            //clears everything and resets the screen up again
            checkBoxEditOn.Checked = false;
            checkBoxEditOff.Checked = false;
            labelEditFlow.Visible = false;
            textBoxEditFlow.Visible = false;
            buttonEditUp.Visible = false;
            buttonEditDown.Visible = false;
            labelEditStatus.Visible = false;
            checkBoxEditOn.Visible = false;
            checkBoxEditOff.Visible = false;
            labelEditStatus.Visible = false;

            //prints out everything everywhere.
            labelEditSaveOutput.Text = ListOfValves[EditValveIndex].ToString();
            int i = 0; System.IO.StringWriter stringwriter = new System.IO.StringWriter(); string sss = "";
            List<String> SerialNoList = new List<String>();
            while (i + 1 <= ListOfValves.Count())
            {   
                sss += ListOfValves[i];
                
                i++; 
            }
            richTextBox1View.Text = sss;
            buttonEditandSave.Visible = false;
            textBox3EditSerial.Clear();
            textBox3EditSerial.BackColor = Color.White;

            
        }
        //</EDIT AND SAVE BUTTON>

        //decrement valvesetting
        void buttonEditDown_Click(object sender, EventArgs e)
        {
            var_vcopy.DecrementValveSetting(); //if the loaded valve was a variable valve, the loaded valve was cast into a variable valve and copied into this static var_vcopy. Don't need to run the method of finding the appriopriate index again.
            textBoxEditFlow.Text = var_vcopy.ValveSetting.ToString();
        }

        //similiar to decrement valvesetting
        void buttonEditUp_Click(object sender, EventArgs e)
        {
            var_vcopy.IncrementValveSetting();
            textBoxEditFlow.Text = var_vcopy.ValveSetting.ToString();
        }

        //edit checkisboxoff, click this, to check it on and the other check box off. ListofValves[EditValveIndex] is the loaded valve.
        void checkBoxEditOff_Click(object sender, EventArgs e)
        {
            checkBoxEditOn.Checked = false;
            checkBoxEditOff.Checked = true;
            ListOfValves[EditValveIndex].TurnOff();//click checkbox turn off -> turns valve off.
        }

        //similar to checkboxeditoff
        void checkBoxEditOn_Click(object sender, EventArgs e)
        {
            checkBoxEditOn.Checked = true;
            checkBoxEditOff.Checked = false;
            ListOfValves[EditValveIndex].TurnOn();//click checkbox turn on -> turns valve on.
        }

        //CLICK LOAD BUTTON
        //clicking load button also runs the checker as well if the serial number is of the right format and if it's available
        void buttonSerialLoad_Click(object sender, EventArgs e)
        {
            
            //coniditions are set up delibrately like this. The methods which I use to check delibrately revolve around changing the state to its opposite state when certain conditions are met

            bool DigitCheck = true, LengthCheck = false, AvailableCheck = false; //if true, it would change from false to true.//
            //when digitcheck and length check are true, it allows one to run the avialabe check.

            int ListofValvesIncrementer = 0;
            string label1rollingstring = "";

            labelEditLoadStatus.Visible = true;

            if (ListOfValves.Count() == 0) //doesn't run load when no valves are present
            {
                labelEditLoadStatus.Visible = true;
                labelEditLoadStatus.Text = "No Valves Created";
                return; 
            }
            labelEditLoadStatus.Visible = true;
            //length checker
            if (textBox3EditSerial.Text.Count() == 6)
            { LengthCheck = true; }
            else { label1rollingstring += "Wrong Length,\n"; LengthCheck = false; }

            //digit checker
            charincrementer = 0;
            char charchecker = char.Parse(" ");

            while (charincrementer + 1 <= textBox3EditSerial.Text.Count())
            {
                charchecker = textBox3EditSerial.Text[charincrementer];
                if (!char.IsDigit(charchecker))
                { DigitCheck = false; label1rollingstring += "Contains non-digits,\n"; break; }
                charincrementer++;
            }


            //if digit checker and length checker is true, implement originality check.
            if (LengthCheck == true && DigitCheck == true)//runs this check. original is already true.
            {
                if (ListOfValves.Count() > 0)//runs after one thing is created.
                {
                    while (ListofValvesIncrementer + 1 <= ListOfValves.Count())
                    {//starts of at index0
                        if (textBox3EditSerial.Text.ToString() == ListOfValves[ListofValvesIncrementer].SerialNumber)
                        { AvailableCheck = true; EditValveIndex = ListofValvesIncrementer; label1rollingstring += "Avaliable"; break; }
                        
                        if (ListofValvesIncrementer + 1 == ListOfValves.Count())//after checking all of the values and none of them are available
                        { AvailableCheck = false; label1rollingstring += "Unavailable"; }
                        ListofValvesIncrementer++;
                    }

                }
            }
            //at this point, listofvalvesincrementer is the correct index for the selected valve.
            label1SerialNoStatus.Visible = true;
            labelEditLoadStatus.Text = label1rollingstring;

            //have a string label1display which you add to...

            if (LengthCheck == true && DigitCheck == true && AvailableCheck == true)
            {textBox3EditSerial.BackColor = Color.Green; serialedit = true;}
            else { textBox3EditSerial.BackColor = Color.Red; textBox3EditSerial.Clear();  serialedit = false; }



            if (serialedit == true)//if serailno is right, load the valve
            {
                buttonEditandSave.Visible = true;
                labelEditStatus.Visible = true;
                checkBoxEditOn.Visible = true;
                checkBoxEditOff.Visible = true;

                //just loads the item. no check needed for constant... just a tick box.
                if (ListOfValves[ListofValvesIncrementer] is ConstantFlowValve)
                {
                    labelEditStatus.Visible = true;
                    checkBoxEditOn.Visible = true;
                    checkBoxOff.Visible = true;
                    if (ListOfValves[ListofValvesIncrementer].Status == true)
                    {checkBoxEditOn.Checked = true;}
                    else { checkBoxEditOff.Checked = true; }

                }
                else if (ListOfValves[ListofValvesIncrementer] is VariableFlowValve)
                {
                    labelEditStatus.Visible = true;
                    checkBoxEditOn.Visible = true;
                    checkBoxOff.Visible = true;
                    if (ListOfValves[ListofValvesIncrementer].Status == true)
                    { checkBoxEditOn.Checked = true; }
                    else { checkBoxEditOff.Checked = true; }
                    var_vcopy = (VariableFlowValve)ListOfValves[ListofValvesIncrementer];
                    labelEditFlow.Visible = true;
                    textBoxEditFlow.Visible = true;
                    buttonEditUp.Visible = true;
                    buttonEditDown.Visible = true;
                    textBoxEditFlow.Text = var_vcopy.ValveSetting.ToString();
                }

            }
            else { buttonEditandSave.Visible = false; }
        }

        void button1SerialCheck_Click(object sender, EventArgs e)
        {
            bool DigitCheck = true, LengthCheck = false, OriginalCheck = true; //if true, it would stay true.// if false, change it to false
            int ListofValvesIncrementer = 0;
            string label1rollingstring ="";

            if (textBox1.Text.Count() == 6)
            { LengthCheck = true; }
            else { label1rollingstring += "Wrong Length,\n"; LengthCheck = false; }

            charincrementer = 0;
            char charchecker =char.Parse(" ");
            
            while (charincrementer + 1 <= textBox1.Text.Count())
            {
                charchecker = textBox1.Text[charincrementer];
                if (!char.IsDigit(charchecker))
                { DigitCheck = false; label1rollingstring += "Contains non-digits,\n"; break; }
                charincrementer++;
            }
            

            //if digit checker and length checker is true, implement originality check.
            if (LengthCheck == true && DigitCheck == true)//runs this check. original is already true.
            {
                if (ListOfValves.Count() > 0)//runs after one thing is created.
                {
                    while (ListofValvesIncrementer + 1 <= ListOfValves.Count())
                    {//starts of at index0
                        if (textBox1.Text.ToString() == ListOfValves[ListofValvesIncrementer].SerialNumber)
                        { OriginalCheck = false; label1rollingstring += "Not Original, "; break; }
                        ListofValvesIncrementer++;
                    } 

                }
            }

            label1SerialNoStatus.Visible = true;
            label1SerialNoStatus.Text = label1rollingstring;

            //have a string label1display which you add to...

            if (LengthCheck == true && DigitCheck == true && OriginalCheck == true)
            {
                textBox1.BackColor = Color.Green; serialcreate = true;
            }
            else { textBox1.BackColor = Color.Red; serialcreate = false; }


            
            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            {
                button1Create.Visible = true;
            }
            else { button1Create.Visible = false; }



        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Count() == 0)
            { textBox2.BackColor = Color.White; return; }
            

            
            
            string boxstring = textBox2.Text.ToString(); //takes a series of numbers. 123 // 12d

            if (checkBox1Constant.Checked == true)
            {
                char c1 = boxstring.First();// c1 takes last no. inputted 3 // d
                //if it is a digit, store it and then do another check.
                int checkersubtypeint;

                if (char.IsDigit(c1) == true)
                {
                    checkersubtypeint = int.Parse(c1.ToString());
                    if (checkersubtypeint >= 1 && checkersubtypeint <= 3)
                    { textBox2.Text = checkersubtypeint.ToString(); textBox2.BackColor = Color.Green; subtypecreate = true; }
                    else
                    { subtypecreate = false; textBox2.Clear(); textBox2.BackColor = Color.White; }
                }

                else
                {
                    textBox2.BackColor = Color.White;
                    subtypecreate = false;
                    textBox2.Clear();
                }

            }
            
            
            if (checkBox2Variable.Checked == true)
            {//got either 1 or 2 characters and need to check if they are digits.

                char c1 = boxstring.First();// c1 takes last no. inputted 3 // d
                char c2 = boxstring.Last();
                
                //if it is a digit, store it and then do another check.
                int checkersubtypeint;

                if (char.IsDigit(c1) == true && char.IsDigit(c2) == true)
                {
                    checkersubtypeint = int.Parse(c1.ToString());
                    if (int.Parse(boxstring) >= 1 && int.Parse(boxstring) <= 10)
                    { textBox2.Text = boxstring; textBox2.BackColor = Color.Green; subtypecreate = true; }
                    else
                    { subtypecreate = false; textBox2.Clear(); }
                }

                else
                {
                    subtypecreate = false;
                    textBox2.Clear();
                }

                if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
                {
                    button1Create.Visible = true;
                }
                else { button1Create.Visible = false; }


            }


            //now you only have one character in the text box.
            //your could try storing the string and then doing the manipulations...
            
            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            { button1Create.Visible = true; }
            else { button1Create.Visible = false; }

        }

        int charincrementer = 0;
        //<type selection>

        void checkBox1Constant_Click(object sender, EventArgs e)
        {
            typecreate = true;
            checkBox1Constant.Checked = true;
            checkBox2Variable.Checked = false;
            textBox2.Visible = true;
            label5TypeFlowSelector.Text = "SubType"; label5TypeFlowSelector.Visible = true;
            label6Flowtypeinfo.Text = "1. Low 2. Medium 3. High"; label6Flowtypeinfo.Visible = true;

            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            {
                button1Create.Visible = true;
            }
            else { button1Create.Visible = false; }

        }

        
        void checkBox2Variable_Click(object sender, EventArgs e)
        {
            typecreate = true;
            checkBox1Constant.Checked = false;
            checkBox2Variable.Checked = true;
            textBox2.Visible = true;
            label5TypeFlowSelector.Text = "Flow Rate"; label5TypeFlowSelector.Visible = true;
            label6Flowtypeinfo.Text = "1 (Lowest) - 10  (Highest)"; label6Flowtypeinfo.Visible = true;

            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            {
                button1Create.Visible = true;
            }
            else { button1Create.Visible = false; }
        
        }

        
        //</type selection>

        //<status selection>
        void checkBox3On_Click(object sender, EventArgs e)
        {
            statuscreate = true;
            checkBox3On.Checked = true;
            checkBoxOff.Checked = false;
            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            {
                button1Create.Visible = true;
            }
            else { button1Create.Visible = false; }
        }

        void checkBoxOff_Click(object sender, EventArgs e)
        {
            statuscreate = true;
            checkBox3On.Checked = false;
            checkBoxOff.Checked = true;
            if (serialcreate == true && statuscreate == true && typecreate == true && subtypecreate == true)
            {
                button1Create.Visible = true;
            }
            else { button1Create.Visible = false; }
        
        }

        //</status selection>
        
        //only make the create button visible when all of the necessary options have been made...
        void button1Create_Click(object sender, EventArgs e)
        {
            if (checkBox1Constant.Checked == true)
            {
                ListOfValves.Add(new ConstantFlowValve(textBox1.Text.ToString(),checkBox3On.Checked, int.Parse(textBox2.Text)));
                int i = 0; System.IO.StringWriter stringwriter = new System.IO.StringWriter(); string sss = "";
                
                while (i +1 <= ListOfValves.Count())
                { sss += ListOfValves[i] + "\n"; i++; }
                richTextBox1View.Text = sss;

                i = 0;  sss = "";
                while (i + 1 <= ListOfValves.Count())
                {
                    sss += ListOfValves[i].SerialNumber;
                    if (ListOfValves[i] is ConstantFlowValve)
                    { sss += "(C)\n"; }
                    else
                    { sss += "(V)\n"; }
                    i++;
                } richTextBox1EditList.Text = sss;

                labelOutput.Visible = true;
                labelOutput.Text = ListOfValves.Last().ToString();
                button1Create.Visible = false;
                textBox1.Clear(); textBox2.Clear();
                checkBox1Constant.Checked = false; checkBox2Variable.Checked = false;
                checkBox3On.Checked = false; checkBoxOff.Checked = false;
                button1Create.Visible = false;
                serialcreate = false; statuscreate = false; typecreate = false; subtypecreate = false;
                textBox1.BackColor = Color.White;
            }
            else if (checkBox1Constant.Checked == false)
            {
                ListOfValves.Add(new VariableFlowValve(textBox1.Text.ToString(), checkBox3On.Checked, int.Parse(textBox2.Text)));
                int i = 0; System.IO.StringWriter stringwriter = new System.IO.StringWriter(); string sss = "";
                while (i + 1 <= ListOfValves.Count())
                { sss += ListOfValves[i] + "\n"; i++; }
                richTextBox1View.Text = sss;


                i = 0; sss = "";
                while (i + 1 <= ListOfValves.Count())
                {
                    sss += ListOfValves[i].SerialNumber;
                    if (ListOfValves[i] is ConstantFlowValve)
                    { sss += "(C)\n"; }
                    else
                    { sss += "(V)\n"; }
                    i++;
                } richTextBox1EditList.Text = sss;

                
                labelOutput.Visible = true;
                labelOutput.Text = ListOfValves.Last().ToString();
                button1Create.Visible = false;
                textBox1.Clear(); textBox2.Clear();
                checkBox1Constant.Checked = false; checkBox2Variable.Checked = false;
                checkBox3On.Checked = false; checkBoxOff.Checked = false;
                button1Create.Visible = false;
                serialcreate = false; statuscreate = false; typecreate = false; subtypecreate = false;
                textBox1.BackColor = Color.White;
            }


        }

        
    }
}

/*
 * Form1 Pseudo Code

The layout is 3 tabs – Create, View and Edit.
Create – For setting the information for creating a new valve object.
View – A big message box to print out the created objects.
Edit – Loads created valves and allows one to edit and save the changes.

Create
The main idea is that the program would only allow you to create the valve object once all of the necessary information has been filled in correctly. After each property of the valve class has been filled in correctly by the user, it returns a bool respective setting the valve’s property. Only when all of the information is set correctly and all the conditions are satisfied would the “Create” button appear and thus allowing you to create the object. The created objects are added to a list.

Check Format Pseudo Code
4 conditions/checks need to be verified before the create button is visible (before you are allowed to create a valve). Four conditions are the serial check, status input, type selection and valve setting.
Serial no. Check – this itself contains three checks and is run when you click the “check format” button. The three checks are to make sure it is of the right length, make sure that all of the characters are digits and to make sure that it is original. If all three of these are true, it sets the bool serialcreate = true.
Check 1: Check Length, if textbox.text != 6, return; and jumps straight out.

Check 2: DigitCheck.
Int i = 0;
While (i +1 <= textbox.text.count)
{
Char c1 = textbox.text.tostring()[i];
If (c1 is not a digit) {digtcheck = false; break;}
i++;
}

If lengthcheck digit chck and original check are all true -> textbox turns green and serial create is true. If not, textbox is red and serial create is false.

This section is run after every single event so it should matter which order the the information is inputted.
If serialcreate, statuscreate, typecreate and subtypecreate are all true, than the button would become visibile.

For pairing group boxes together, the check boxes in the Create tab follow similar suit.
Void checkboxOn_Click {checkboxon.checked = true; checkedboxoff.checked = false;  statuscreate = true;}

Similar would be for choosing between checked boxes for Constant and Variable. It would include the same as above.
Void checkboxConstant_Click {set this box on, set the other one off. The subtype info label would read “Subtype” and the other label would say “1. Low, 2. Medium, 3. High.”  and also makes the textbox for inputting the value visible.}

Void checkboxVariable_click{ set this box on, set the other one off. The subtype info label would read “Flowsetting” and the other label would say “1. Low, - 10. High.”  and also makes the textbox for inputting the value textbox visible.}

Variable text has a method which only allows for you to input values within a certain range.
If constant flow valve was selected, than the range is 1-3 and ints only. If it was variable, the range would be 1-10.

String boxstring = textbox2.text.tostring.

Char c1 is the first element in the string.
If c1 is a digit, c1 is changed to an int and compared to see if it’s in the range of 1-3. If it is, the textbox displays this, turn green and subtypecreate = true. Or else, subtype would be false, color is white and text box is cleared.

If one would want to create a variable valve. Range would be 1 - 10
Char c1 = boxstring.First();
Char c2 = boxstring. Last ();  (to cater for 2 digit no. 10, if there is only one digit, than both c1 and c2 would be the same as they would both be the first and last element in that string.
If both c1 and c2 are digits, then if 1<= int.parse(boxstring) <= 10, textbox2.text = boxstring, textbox color is green, subtype create is true.
Else, subtypecreate is false and the textbox is cleared, thus only allowing something to input nos between 1-10.

Create button.
Clears all inputted fields, outputs the info in a label.
 Overrided tostring method from the valve class hands formatting.
Prints the list entire list of the valves in the “View” tab.
Int i = 0;
String s= “ “;

If constant valve check is checked, then ListofVavles.Add(new constantvalve(textbox.text.tostring, checkboxon.checked/*this would be status true or false and checked state returns a Boolean of either true or false*//*, int.Parse(textbox2.text)));
Else ifvariable valve check is checked, the constant check box would be unchecked.... listofvalves.add(new variablevalve(textbox.text.tostring,checkboxon.checked, int.parse (textbox2.text));

While (i +1 <= listofvalves.count())
{
S += listofvalves[i].tostring + “\n”;
i++;
}
Viewoutputtextbox.text = s;

For the load tab it is similar.
 I=0; sss =””;
While (i +1 <= Listofvalves.count())
S +=listofvavles[i].serialnumber;
If (listofvalves[i] is constant valve) {s+= “C \n”}
Else {s+= “V\n”} //c and v are just labels to say if they are constant or variable.
Loadtextboxlist = s

Window is set to its original state and everything is cleared and all of the information is outputted in all of the necessary places.


The Load screen.

Type in a serial no and runs checks to find it.
If there are no valves created than it doesn’t do the check.

If not the right length, labelrollingstring += “wrong length”; lengthcheck = false;

Charincrementer = 0
While (charincrementer  + 1 <= no. of elements in string)
Charchecker = textbox3editeserial.text(charincrementer)
If charchecker is not a digit.
Digit checker is false and label rolling string+= “contains non-digits”

If both correct length and contains digits -> run this while (listof vavlesincrementer +1 <= no of elements in list of vales.)
{
If textboxstring == listofvalves[listofvavlesincrementer].serial number -> available check =true, static editvalveindex = listofvalvesincrementer; break;

If it reaches the last position/checks all of the serial numbers with no match, then available check is false
Listofvalveincremeter++;

}

Output all the bits of the rolling string.
If all checks are true, the textbox would go green serialedit would be true and thus allowing making all of the other areas visible and allowing you to edit the elements.

If loaded valve is a constant valve, only the status options would pop up.
Checkboxturnon would run listofvalves[editvalveindex/*assigned after string check was true*//*].TurnOn()
Opposite would apply to checkboxturnoff.

If a variable valve is created, both the status and also the valve settings up and down would be available too.
The listofvavles[editvalveindex] would need to be casted into a copy variablevalve object var_vcopy so as to get access to its properties and its methods.

Upbotton -> {var_vcopy.increment(); output current valve setting}
Downbutton -> {var_vcopy.decrement();output current valve setting}

Edit and save button clears all areas, and refreshes the output in the View tab.

 * 
*/