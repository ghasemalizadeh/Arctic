using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticProblem1
{
    public class TreeNode
    {

        public TreeNode(int value, TreeNode parent)
        {
            try
            {
               this.Value = value;
               this.Parent = parent;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                throw new ArgumentOutOfRangeException();


            }
        }
        public int Value { get; set; }


        public int Sum
        {
            get {
                
                    if (this.Parent != null)
                    {
                        var parentSum = this.Parent.Sum;

                     if(parentSum < 0)
                       {
                        if(parentSum == Int32.MinValue)
                        {
                            if (this.Value > 0)
                                return parentSum + this.Value;
                            else throw new ArgumentOutOfRangeException();

                        }else
                            if (Int32.MinValue - parentSum < this.Value)
                            throw new ArgumentOutOfRangeException();


                      }
                    if (parentSum > 0)
                    {
                        if (parentSum == Int32.MaxValue)
                        {
                            if (this.Value < 0)
                                return parentSum + this.Value;
                            else throw new ArgumentOutOfRangeException();

                        }
                        else
                            if (Int32.MaxValue - parentSum < this.Value)
                            throw new ArgumentOutOfRangeException();


                    }
                    return this.Parent.Sum + Value;
                 
                }
                    else
                        return this.Value;
               
            }
            
        }
        public TreeNode Parent { get; set; }

        

    }
}
