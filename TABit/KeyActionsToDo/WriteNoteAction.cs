using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class WriteNoteAction : KeyAction
    {
        private int ToWrite;
        int length1;
        Note not1;
        int fret1;
        int startpoint1;
        int stringnumber1;
        decimal linesBetween;
        int strings;
        int line1;

        public WriteNoteAction(int ToWrite, int length, int strings) 
        {
            this.ToWrite = ToWrite;
            this.length1 = length;
            this.strings = strings;
        }


        public void doKeyAction(TextBox box)
        {
            
           if (ToWrite==49|| ToWrite==97)
           {
               fret1 = 1;
           }
           else if(ToWrite==50||ToWrite==98)
           {
               fret1=2;
           }
           else if(ToWrite==51||ToWrite==99)
           {
               fret1=3;
           }
           else if(ToWrite==52||ToWrite==100)
           {
               fret1=4;
           }
           else if(ToWrite==53||ToWrite==101)
           {
               fret1=5;
           }
           else if(ToWrite==54||ToWrite==102)
           {
               fret1=6;
           }
            else if(ToWrite==55||ToWrite==103)
           {
               fret1=7;
           }
            else if(ToWrite==56||ToWrite==104)
           {
               fret1=8;
           }
            else if(ToWrite==57||ToWrite==105)
           {
               fret1=9;
           }
           else if(ToWrite==48||ToWrite==96)
           {
               fret1=0;
           }
           else if(ToWrite==88)
           {
               fret1=-1;
           }



            var currentLine = box.GetLineFromCharIndex(box.SelectionStart)+1;

            

            linesBetween = Config.getLinesBetweenBlocks();

            decimal Blocklength = linesBetween + strings;


            int currentBlock = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(currentLine / Blocklength)));

            int CurrentPositionInBlock = Convert.ToInt32(currentLine - (Math.Floor(Convert.ToDecimal(currentLine / Blocklength)) * Blocklength));


            if(CurrentPositionInBlock>strings)
            {
                line1=-1;
            }
            else
            {
                line1=CurrentPositionInBlock;
            }
            
           

            KeysConverter kc = new KeysConverter();

            startpoint1 = box.SelectionStart;

            string Writting = kc.ConvertToString(ToWrite);
                
            box.Text = box.Text.Insert(box.SelectionStart, Writting);



            box.Select(startpoint1+Writting.Length , 0);

            not1 = new Note(fret1,length1,line1,startpoint1);
        }
    }
}
