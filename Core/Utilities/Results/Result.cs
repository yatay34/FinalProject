using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    { 
        public Result(bool success, string message) :this(success)
        {
            ////Success = success;
            Message = message;
        }
        //constructor Overloading
        public Result(bool success)
        {
            Success = success;
        }

        //public bool Success => throw new NotImplementedException();

        public bool Success { get; }
        public string Message { get; }
    }
}
