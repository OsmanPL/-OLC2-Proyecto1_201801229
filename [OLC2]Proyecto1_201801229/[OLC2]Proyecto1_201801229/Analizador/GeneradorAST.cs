using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Irony;
using Irony.Parsing;
using System.Text;
using _OLC2_Proyecto1_201801229.Interfaces;
using Irony.Ast;
using System.Windows.Forms;

namespace _OLC2_Proyecto1_201801229.Analizador
{
    class GeneradorAST
    {
        public void analizar(string codigo)
        {
            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(codigo);
            ParseTreeNode raiz = arbol.Root;
            Reporte reporte = new Reporte();
            if (raiz != null && arbol.ParserMessages.Count == 0)
            {
                Instruccion AST = metodoProgram(raiz.ChildNodes.ElementAt(0));

                reporte.graficarArbol(raiz);
            }
            else
            {
                for (int i = 0; i < arbol.ParserMessages.Count; i++)
                {
                    MessageBox.Show("Error: " + arbol.ParserMessages.ElementAt(i).Message + " " + arbol.ParserMessages.ElementAt(i).Location);
                }
            }
        }

        private LinkedList<Instruccion> Instrucciones(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 2)
            {
                LinkedList<Instruccion> listaInstrucciones = Instrucciones(nodoActual.ChildNodes.ElementAt(0));
                listaInstrucciones.AddLast(metodoInstruccion(nodoActual.ChildNodes.ElementAt(1)));
                return listaInstrucciones;

            }
            else if (nodoActual.ChildNodes.Count == 1)
            {
                LinkedList<Instruccion> listaInstrucciones = new LinkedList<Instruccion>();
                listaInstrucciones.AddLast(metodoInstruccion(nodoActual.ChildNodes.ElementAt(0)));
                return listaInstrucciones;
            }
            else
            {
                return null;
            }
        }

        private Instruccion metodoInstruccion(ParseTreeNode nodoActual)
        {
            String sentencia = nodoActual.ChildNodes.ElementAt(0).Term.Name;
            switch (sentencia)
            {
                case "NT_program":
                    return metodoProgram(nodoActual.ChildNodes.ElementAt(0));
                case "NT_declaracion":
                    return metodoDeclaracion(nodoActual.ChildNodes.ElementAt(0));
                case "NT_asignacion":
                    return metodoAsignacion(nodoActual.ChildNodes.ElementAt(0));
                case "NT_type":
                    return metodoTypeArray(nodoActual.ChildNodes.ElementAt(0)); ;
            }
            return null;
        }

        private Instruccion metodoProgram(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 8)
            {
                return new Programa(Instrucciones(nodoActual.ChildNodes.ElementAt(3)), Instrucciones(nodoActual.ChildNodes.ElementAt(5)));
            }
            else
            {
                return null;
            }
        }

        private Declaracion metodoDeclaracion(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 5)
            {
                String tipovar = nodoActual.ChildNodes.ElementAt(0).Term.Name.ToString().ToLower();
                if (tipovar.Equals("var"))
                {
                    Simbolo.TipoDato tipo = NT_tipo_VAR(nodoActual.ChildNodes.ElementAt(3));
                    Object valorDafult = valorDefecto(tipo);
                    Operacion.Tipo_operacion tip = tipOp(tipo);
                    return new Declaracion(listaVariables(nodoActual.ChildNodes.ElementAt(1)), tipo, new Operacion(valorDafult, tip), Simbolo.TipoVarariable.VAR, NT_tipo(nodoActual.ChildNodes.ElementAt(3)), true);
                }
                else if (tipovar.Equals("const"))
                {
                    return new Declaracion(nodoActual.ChildNodes.ElementAt(1).ToString(), Simbolo.TipoDato.OBJECT, metodoExpresion(nodoActual.ChildNodes.ElementAt(3)), Simbolo.TipoVarariable.CONST, "", false);
                }
            }
            else if (nodoActual.ChildNodes.Count == 1)
            {
                return iniciallizarVariable(nodoActual.ChildNodes.ElementAt(0));
            }
            return null;
        }

        private Declaracion iniciallizarVariable(ParseTreeNode nodoActual)
        {
            Simbolo.TipoDato tipo = NT_tipo_VAR(nodoActual.ChildNodes.ElementAt(3));
            bool t = valorvacio(nodoActual.ChildNodes.ElementAt(4));
            if (t)
            {
                return new Declaracion(nodoActual.ChildNodes.ElementAt(1).ToString().Split(' ')[0], tipo, ini(nodoActual.ChildNodes.ElementAt(4)), Simbolo.TipoVarariable.VAR, NT_tipo(nodoActual.ChildNodes.ElementAt(3)), false);
            }
            else
            {
                Object val = valorDefecto(tipo);
                Operacion.Tipo_operacion tip = tipOp(tipo);
                return new Declaracion(nodoActual.ChildNodes.ElementAt(1).ToString().Split(' ')[0], tipo, new Operacion(val, tip), Simbolo.TipoVarariable.VAR, NT_tipo(nodoActual.ChildNodes.ElementAt(3)), false);
            }

        }
        private Operacion.Tipo_operacion tipOp(Simbolo.TipoDato tipo)
        {
            switch (tipo)
            {
                case Simbolo.TipoDato.BOOLEAN:
                    return Operacion.Tipo_operacion.BOOLEAN;
                case Simbolo.TipoDato.INTEGER:
                    return Operacion.Tipo_operacion.NUMERO;
                case Simbolo.TipoDato.OBJECT:
                    return Operacion.Tipo_operacion.OBJECT;
                case Simbolo.TipoDato.REAL:
                    return Operacion.Tipo_operacion.DECIMAL;
                case Simbolo.TipoDato.STRING:
                    return Operacion.Tipo_operacion.CADENA;
                case Simbolo.TipoDato.IDENTIFICADOR:
                    return Operacion.Tipo_operacion.IDENTIFICADOR;
                default:
                    return Operacion.Tipo_operacion.IDENTIFICADOR;
            }
        }
        private Operacion ini(ParseTreeNode nodoActual)
        {
            return metodoExpresion(nodoActual.ChildNodes.ElementAt(1));
        }
        private bool valorvacio(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 2)
            {
                return true;
            }
            return false;
        }

        private Operacion metodoExpresion(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 3)
            {
                string operador = nodoActual.ChildNodes.ElementAt(1).ToString().Split(' ')[0];
                switch (operador)
                {
                    case "+":
                        return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.SUMA);
                    case "-":
                        return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.RESTA);
                    case "/":
                        return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.DIVISION);
                    case "*":
                        return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.MULTIPLICACION);
                    case "%":
                        return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.MODULAR);
                    case "(":
                        return new Operacion(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0], Operacion.Tipo_operacion.LLAMADAPROCEDIMIENTO);
                    default:
                        return metodoExpresion(nodoActual.ChildNodes.ElementAt(1));
                }
            }
            else if (nodoActual.ChildNodes.Count == 2)
            {
                return new Operacion(metodoExpresion(nodoActual.ChildNodes.ElementAt(1)), Operacion.Tipo_operacion.NEGATIVO);
            }
            else if (nodoActual.ChildNodes.Count == 4)
            {
                return new Operacion(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0], valoresParametros(nodoActual.ChildNodes.ElementAt(2)), Operacion.Tipo_operacion.LLAMADAFUNCION);
            }
            else
            {
                string operador = "";
                Object valor = "";

                operador = NT_valor(nodoActual.ChildNodes.ElementAt(0));
                valor = NT_valor_valor(nodoActual.ChildNodes.ElementAt(0)).ToString().Split(' ')[0];

                Console.WriteLine(operador);
                Console.WriteLine(valor);
                switch (operador.ToLower().Split(' ')[0])
                {
                    case "cadena":
                        return new Operacion(valor, Operacion.Tipo_operacion.CADENA);
                    case "numero":
                        return new Operacion(valor, Operacion.Tipo_operacion.NUMERO);
                    case "real":
                        return new Operacion(valor, Operacion.Tipo_operacion.DECIMAL);
                    case "true":
                        return new Operacion(valor, Operacion.Tipo_operacion.BOOLEAN);
                    case "false":
                        return new Operacion(valor, Operacion.Tipo_operacion.BOOLEAN);
                    case "object":
                        return new Operacion(valor, Operacion.Tipo_operacion.OBJECT);
                    default:
                        return new Operacion(valor, Operacion.Tipo_operacion.IDENTIFICADOR);
                }

            }
        }

        private LinkedList<Operacion> valoresParametros(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 3)
            {
                LinkedList<Operacion> operaciones = valoresParametros(nodoActual.ChildNodes.ElementAt(0));
                operaciones.AddLast(metodoExpresion(nodoActual.ChildNodes.ElementAt(2)));
                return operaciones;
            }
            else if (nodoActual.ChildNodes.Count == 1)
            {
                LinkedList<Operacion> operaciones = new LinkedList<Operacion>();
                operaciones.AddLast(metodoExpresion(nodoActual.ChildNodes.ElementAt(0)));
                return operaciones;
            }
            return null;
        }

        private LinkedList<String> listaVariables(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 3)
            {
                LinkedList<String> listaVar = listaVariables(nodoActual.ChildNodes.ElementAt(0));
                listaVar.AddLast(nodoActual.ChildNodes.ElementAt(2).ToString().Split(' ')[0]);
                return listaVar;
            }
            else if (nodoActual.ChildNodes.Count == 1)
            {
                LinkedList<String> listaVar = new LinkedList<String>();
                listaVar.AddLast(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0]);
                return listaVar;
            }
            return null;
        }

        private String NT_tipo(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 0)
            {
                return nodoActual.ToString().Split(' ')[0];
            }
            else
            {
                return nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0];
            }
        }

        private Simbolo.TipoDato buscarTipoDato(String buscar)
        {
            switch (buscar.ToLower().Split(' ')[0])
            {
                case "integer":
                    return Simbolo.TipoDato.INTEGER;
                case "string":
                    return Simbolo.TipoDato.STRING;
                case "boolean":
                    return Simbolo.TipoDato.BOOLEAN;
                case "real":
                    return Simbolo.TipoDato.REAL;
                case "object":
                    return Simbolo.TipoDato.OBJECT;
                default:
                    return Simbolo.TipoDato.IDENTIFICADOR;
            }
        }
        private Object valorDefecto(Simbolo.TipoDato tipo)
        {
            switch (tipo)
            {
                case Simbolo.TipoDato.INTEGER:
                    return 0;
                case Simbolo.TipoDato.STRING:
                    return "";
                case Simbolo.TipoDato.REAL:
                    return 0;
                case Simbolo.TipoDato.BOOLEAN:
                    return false;
                case Simbolo.TipoDato.OBJECT:
                    return "";
                default:
                    return "";
            }
        }
        private String NT_valor(ParseTreeNode nodoActual)
        {
            return nodoActual.ChildNodes.ElementAt(0).Term.Name.ToString().ToLower().Split(' ')[0];
        }
        private Object NT_valor_valor(ParseTreeNode nodoActual)
        {
            return nodoActual.ChildNodes.ElementAt(0);
        }
        private Simbolo.TipoDato NT_tipo_VAR(ParseTreeNode nodoActual)
        {
            return buscarTipoDato(nodoActual.ChildNodes.ElementAt(0).ToString().ToLower().Split(' ')[0]);
        }

        private Asignacion metodoAsignacion(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 4)
            {
                return new Asignacion(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0], metodoExpresion(nodoActual.ChildNodes.ElementAt(2)));
            }
            else if (nodoActual.ChildNodes.Count == 6)
            {
                return new Asignacion(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0], metodoExpresion(nodoActual.ChildNodes.ElementAt(4)), nodoActual.ChildNodes.ElementAt(2).ToString().Split(' ')[0]);
            }
            else if (nodoActual.ChildNodes.Count == 7)
            {
                return new Asignacion(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0], metodoExpresion(nodoActual.ChildNodes.ElementAt(5)), metodoExpresion(nodoActual.ChildNodes.ElementAt(2)));
            }
            return null;
        }
        private Instruccion metodoTypeArray(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 2)
            {
                return metodoSeparar(nodoActual.ChildNodes.ElementAt(1));
            }
            return null;
        }
        private Instruccion metodoSeparar(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 5)
            {

            }
            else if (nodoActual.ChildNodes.Count == 4)
            {
                return metodoArray(nodoActual.ChildNodes.ElementAt(3), nodoActual.ChildNodes.ElementAt(0));
            }
            return null;
        }
        private ArrayPascal metodoArray(ParseTreeNode nodoActual, ParseTreeNode identificador)
        {
            if (nodoActual.ChildNodes.Count == 6)
            {
                Simbolo.TipoDato tipo1 = Simbolo.TipoDato.OBJECT;
                String tipoS1 = "";
                Operacion limizq1 = new Operacion();
                Operacion limder1 = new Operacion();
                Simbolo.TipoDato tipo2 = Simbolo.TipoDato.OBJECT;
                String tipoS2 = "";
                Operacion limizq2 = new Operacion();
                Operacion limder2 = new Operacion();
                bool indices = TipoIndice(nodoActual.ChildNodes.ElementAt(1));
                if (indices)
                {
                    tipo1 = TipoDatoIndice(nodoActual.ChildNodes.ElementAt(1));
                    tipoS1 = TipoDatoIndiceString(nodoActual.ChildNodes.ElementAt(1));
                }
                else
                {
                    limizq1 = LimiteIzquierdo(nodoActual.ChildNodes.ElementAt(1));
                    limder1 = LimiteDerecho(nodoActual.ChildNodes.ElementAt(1));
                }
                bool ind = TipoIndice(nodoActual.ChildNodes.ElementAt(4));
                if (ind)
                {
                    tipo2 = TipoDatoIndice(nodoActual.ChildNodes.ElementAt(4));
                    tipoS2 = TipoDatoIndiceString(nodoActual.ChildNodes.ElementAt(4));
                }
                else
                {
                    limizq2 = LimiteIzquierdo(nodoActual.ChildNodes.ElementAt(4));
                    limder2 = LimiteDerecho(nodoActual.ChildNodes.ElementAt(4));
                }

                if (indices && ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], tipo2, tipo1, tipoS1, ArrayPascal.TipoArray.T_T, tipoS2);
                }
                else if (indices && !ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq2, limder2, tipo1, tipoS1, ArrayPascal.TipoArray.T_Op);
                }
                else if (!indices && ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq1, limder1, tipo2, tipoS2, ArrayPascal.TipoArray.Op_T);
                }
                else
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq1, limder1, limizq2, limder2, ArrayPascal.TipoArray.Op_Op);
                }
            }
            else if (nodoActual.ChildNodes.Count == 7)
            {

                Simbolo.TipoDato tipo1 = Simbolo.TipoDato.OBJECT;
                String tipoS1 = "";
                Operacion limizq1 = new Operacion();
                Operacion limder1 = new Operacion();
                Simbolo.TipoDato tipo2 = Simbolo.TipoDato.OBJECT;
                String tipoS2 = "";
                Operacion limizq2 = new Operacion();
                Operacion limder2 = new Operacion();
                bool indices = TipoIndice(nodoActual.ChildNodes.ElementAt(2));
                if (indices)
                {
                    tipo1 = TipoDatoIndice(nodoActual.ChildNodes.ElementAt(2));
                    tipoS1 = TipoDatoIndiceString(nodoActual.ChildNodes.ElementAt(2));
                }
                else
                {
                    limizq1 = LimiteIzquierdo(nodoActual.ChildNodes.ElementAt(2));
                    limder1 = LimiteDerecho(nodoActual.ChildNodes.ElementAt(2));
                }
                bool ind = TipoIndice(nodoActual.ChildNodes.ElementAt(5));
                if (ind)
                {
                    tipo2 = TipoDatoIndice(nodoActual.ChildNodes.ElementAt(5));
                    tipoS2 = TipoDatoIndiceString(nodoActual.ChildNodes.ElementAt(5));
                }
                else
                {
                    limizq2 = LimiteIzquierdo(nodoActual.ChildNodes.ElementAt(5));
                    limder2 = LimiteDerecho(nodoActual.ChildNodes.ElementAt(5));
                }

                if (indices && ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], tipo2, tipo1, tipoS1, ArrayPascal.TipoArray.T_T, tipoS2);
                }
                else if (indices && !ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq2, limder2, tipo1, tipoS1, ArrayPascal.TipoArray.T_Op);
                }
                else if (!indices && ind)
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq1, limder1, tipo2, tipoS2, ArrayPascal.TipoArray.Op_T);
                }
                else
                {
                    return new ArrayPascal(identificador.ToString().Split(' ')[0], limizq1, limder1, limizq2, limder2, ArrayPascal.TipoArray.Op_Op);
                }
            }
            return null;
        }
        private bool TipoIndice(ParseTreeNode nodoActual)
        {
            if (nodoActual.ChildNodes.Count == 1)
            {
                return true;
            }
            return false;
        }
        private Simbolo.TipoDato TipoDatoIndice(ParseTreeNode nodoActual)
        {
            return buscarTipoDato(nodoActual.ChildNodes.ElementAt(0).ToString().Split(' ')[0].ToLower());
        }
        private String TipoDatoIndiceString(ParseTreeNode nodoActual)
        {
            return NT_tipo(nodoActual.ChildNodes.ElementAt(0));
        }
        private Operacion LimiteIzquierdo(ParseTreeNode nodoActual)
        {
            return metodoExpresion(nodoActual.ChildNodes.ElementAt(0));
        }
        private Operacion LimiteDerecho(ParseTreeNode nodoActual)
        {
            return metodoExpresion(nodoActual.ChildNodes.ElementAt(3));
        }
    }
}
