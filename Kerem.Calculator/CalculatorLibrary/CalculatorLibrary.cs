using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary ;

    public class Calculator
    {
        readonly JsonWriter _writer;
        
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.json");
            Trace.AutoFlush = true;
            _writer = new JsonTextWriter(logFile);
            _writer.Formatting = Formatting.Indented;
            _writer.WriteStartObject();
            _writer.WritePropertyName("Operations");
            _writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            _writer.WriteStartObject();
            _writer.WritePropertyName("Operand1");
            _writer.WriteValue(num1);
            _writer.WritePropertyName("Operand2");
            _writer.WriteValue(num2);
            _writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    _writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    _writer.WriteValue("Subtract");

                    break;
                case "m":
                    result = num1 * num2;
                    _writer.WriteValue("Multiply");

                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    _writer.WriteValue("Divide");
                    break;
                case "r":
                    result = Math.Sqrt(num1 + num2);
                    _writer.WriteValue("Square Root");
                    break;
                case "p":
                    result = Math.Pow(num1, num2);
                    _writer.WriteValue("Taking the power");
                    break;
                default:
                    _writer.WriteValue($"Unknown operation {op}");
                    break;
            }
            _writer.WritePropertyName("Result");
            _writer.WriteValue(result);
            _writer.WriteEndObject();
            return result;
        }

        public void Finish()
        {
            _writer.WriteEndArray();
            _writer.WriteEndObject();
            _writer.Close();
        }
    }