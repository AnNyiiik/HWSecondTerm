using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Calculator;

public class CalculationHandler
{
    public enum States
    {
        AwaitSecondOperand,
        AwaitCharacter,
        ZeroDivision
    }

    private States _currentState;

    private char? operation;

    public CalculationHandler()
    {
        _currentState = States.AwaitCharacter;
        operand = new StringBuilder();
        acc = null;
    }

    private double? acc;

    public string Acc
    {
        get
        {
            if (_currentState == States.ZeroDivision)
            {
                return "Error";
            }
            else if (acc == null)
            {
                if (operand.Length == 0)
                {
                    return "0";
                }
                return operand.ToString();
            }
            if (operand.Length == 0)
            {
                return acc.ToString();
            }
            return operand.ToString();
        }
    }

    private StringBuilder operand;

    private bool isDouble;

    public void CalculationProcess(string character)
    {
        switch (_currentState)
        {
            case States.ZeroDivision:
                if (character.Equals("C"))
                {
                    _currentState = States.AwaitCharacter;
                }
                break;

            case States.AwaitCharacter:

                if (character[0] >= '0' && character[0] <= '9')
                {
                    operand.Append(character);

                }
                else if (character[0] == ',' || character[0] == '.')
                {
                    if (operand.Length == 0 || isDouble)
                    {
                        break;
                    }
                    operand.Append(character);
                    isDouble = true;

                }
                else if (character.Equals("-") || character.Equals("+") || character.Equals("/")
                        || character.Equals("*") || character.Equals("="))
                {
                    isDouble = false;
                    if (acc == null)
                    {
                        _currentState = States.AwaitSecondOperand;
                        operation = character[0];
                        if (operand.Length != 0)
                        {
                            acc = Double.Parse(operand.ToString());
                        }
                        operand.Clear();
                        break;
                    }
                    switch (operation)
                    {
                        case '+':
                            acc += Double.Parse(operand.ToString());
                            operand.Clear();
                            _currentState = States.AwaitSecondOperand;
                            break;
                        case '-':
                            acc -= Double.Parse(operand.ToString());
                            operand.Clear();
                            _currentState = States.AwaitSecondOperand;
                            break;
                        case '*':
                            acc *= Double.Parse(operand.ToString());
                            operand.Clear();
                            _currentState = States.AwaitSecondOperand;
                            break;
                        case '/':
                            var divisor = Double.Parse(operand.ToString());
                            operand.Clear();
                            if (divisor == 0)
                            {
                                acc = null;
                                _currentState = States.ZeroDivision;
                                break;
                            }
                            acc /= divisor;
                            _currentState = States.AwaitSecondOperand;
                            break;
                        case null:
                            acc = Double.Parse(operand.ToString());
                            operand.Clear();
                            break;
                    }
                    operation = character[0];
                }
                else if (character.Equals("C"))
                {
                    operand.Clear();
                    isDouble = false;
                    acc = null;
                }
                else if (character.Equals("+/-"))
                {
                    if (operand.Length != 0)
                    {
                        operand = operand.Insert(0, "-");
                        break;
                    }
                    acc = -acc;
                }
                break;

            case States.AwaitSecondOperand:
                if (character.Equals("-") || character.Equals("+") || character.Equals("/") || character.Equals("*"))
                {
                    operation = character[0];
                    break;
                }
                if (character[0] >= '0' && character[0] <= '9')
                {
                    operand.Append(character);
                    _currentState = States.AwaitCharacter;
                    break;
                }
                if (character.Equals("C"))
                {
                    operand.Clear();
                    acc = null;
                }
                if (character.Equals("+/-"))
                {
                    acc = 0;
                }
                if (character.Equals("="))
                {
                    switch (operation)
                    {
                        case '+':
                            acc += acc;
                            break;
                        case '-':
                            acc -= acc;
                            break;
                        case '*':
                            acc *= acc;
                            break;
                        case '/':
                            if (acc == 0)
                            {
                                _currentState = States.ZeroDivision;
                                break;
                            }
                            acc /= acc;
                            break;
                    }
                    operation = null;
                    operand.Clear();
                }
                break;
        }
    }
}