using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Expression
    {
        public float OperandOne { get; set; }
        public float OperandTwo { get; set; }
        public string Operation { get; set; }

        public Expression(float operandOne, float operandTwo, string operation)
        {
            this.OperandOne = operandOne;
            this.OperandTwo = operandTwo;
            this.Operation = operation;
        }

        public override string ToString()
        {
            return $"{OperandOne} {Operation} {OperandTwo}";
        }
    }
}
