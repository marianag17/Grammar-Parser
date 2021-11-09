using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Parser
    {
        Scanner _scanner;
        Token _token;
        string noTerminalInicial = "", VariableActual = "", reglasUnidas = "";
        List<string> terminales = new List<string>();
        List<string> variables = new List<string>();
        List<string> reglas = new List<string>();
        public string initializeGrammar(string Texto)
        {
            _scanner = new Scanner(Texto);
            _token = _scanner.GetToken();

            string Answer = "";

            if (_token.Tag == "Variable")
            {
                VariableActual = _token.Value + "->";
                noTerminalInicial = _token.Value;
                variables.Add(_token.Value);
                Answer = i1();
            }

            return Answer;
        }

        public string i1()
        {
            _token = _scanner.GetToken();
            if (_token.Tag == "DobPoint")
                return i2();
            else
                return "Error en la gramática";
        }

        public string i2()
        {
            _token = _scanner.GetToken();
            if (_token.Tag == "Variable" || _token.Tag == "Terminal" || _token.Tag == "Pleca" || _token.Tag == "Jump")
            {
                if (_token.Tag == "Variable")
				{
                    reglasUnidas += _token.Value + " ";
                    if (!variables.Contains(_token.Value)) {
                        variables.Add(_token.Value);
                     }
				}
                else if (_token.Tag == "Terminal")
				{
                    reglasUnidas += _token.Value + " ";
                    if (!terminales.Contains(_token.Value))
                    {
                        terminales.Add(_token.Value);
                    }
                }
                else if (_token.Tag == "Pleca")
                {
                    reglas.Add(VariableActual+reglasUnidas);
                    reglasUnidas = "";
                }
                return i2();
            }
            else if (_token.Tag == "PointComa")
            {
                reglas.Add(VariableActual + reglasUnidas);
                reglasUnidas = "";
                return i3();
            }
            else
                return "Error en la gramática";
        }

        public string i3()
        {
            _token = _scanner.GetToken();
            if (_token.Tag == "Jump")
                return i3();
            else if (_token.Tag == "EOF") {
                Grammar grammar = new Grammar(terminales, variables, noTerminalInicial, reglas);
                grammar.imprimir();
                return "Gramática aceptada";
            }
            else if (_token.Tag == "Variable")
            {
                VariableActual = _token.Value + "->";
                return i1();
            }
            else
                return "Error en la gramática";
        }
    }
}
