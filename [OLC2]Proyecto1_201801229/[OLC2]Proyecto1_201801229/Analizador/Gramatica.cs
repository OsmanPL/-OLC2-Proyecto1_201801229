using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace _OLC2_Proyecto1_201801229.Analizador
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {
            #region ER
            IdentifierTerminal IDENTIFICADOR = new IdentifierTerminal("ID");
            StringLiteral CADENA = new StringLiteral("cadena", "\'");
            var NUMERO = new NumberLiteral("numero");
            var DECIMAL = new RegexBasedTerminal("real", "[0-9]+'.'[0-9]+");

            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n");
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "{*", "*}");
            CommentTerminal comentarioMultiple = new CommentTerminal("comentarioMultiple", "{ ", " }");
            #endregion

            #region Terminales
            //Simbolos Numericos
            var TK_SUM = ToTerm("+");
            var TK_RES = ToTerm("-");
            var TK_DIV = ToTerm("/");
            var TK_MUL = ToTerm("*");
            var TK_MOD = ToTerm("%");
                
            //Simbolos Agrupacion
            var TK_PARIZQ = ToTerm("(");
            var TK_PARDER = ToTerm(")");
            var TK_CORIZQ = ToTerm("[");
            var TK_CORDER = ToTerm("]");
            var TK_LLAIZQ = ToTerm("{");
            var TK_LLADER = ToTerm("}");

            //Simbolos Relacionales
            var TK_MAY = ToTerm(">");
            var TK_MEN = ToTerm("<");
            var TK_IGUAL = ToTerm("=");
            var TK_MAYIGUAL = ToTerm(">=");
            var TK_MENIGUAL = ToTerm("<=");
            var TK_DIFERENTE = ToTerm("<>");

            //Simbolos Logicos
            var TK_AND = ToTerm("and");
            var TK_OR = ToTerm("or");
            var TK_NOT = ToTerm("not");

            //Simbolos de Puntuacion
            var TK_PUNTO = ToTerm(".");
            var TK_PYCOMA = ToTerm(";");
            var TK_COMA = ToTerm(",");
            var TK_DOSPUNTOS = ToTerm(":");
            var TK_IGUALAR = ToTerm(":=");

            //Tipos de Datos
            var TK_INTEGER = ToTerm("integer");
            var TK_REAL = ToTerm("real");
            var TK_BOOLEAN = ToTerm("boolean");
            var TK_VOID = ToTerm("void");
            var TK_STRING = ToTerm("string");

            //Palabras Reservadas
            var TK_TRUE = ToTerm("true");
            var TK_FALSE = ToTerm("false");
            var TK_VAR = ToTerm("var");
            var TK_TYPE = ToTerm("type");
            var TK_BEGIN = ToTerm("begin");
            var TK_END = ToTerm("end");
            var TK_PROGRAM = ToTerm("program");
            var TK_OBJECT = ToTerm("object");
            var TK_ARRAY = ToTerm("array");
            var TK_OF = ToTerm("of");
            var TK_TO = ToTerm("to");
            var TK_IF = ToTerm("if");
            var TK_CONST = ToTerm("const");
            var TK_THEN = ToTerm("then");
            var TK_ELSE = ToTerm("else");
            var TK_CASE = ToTerm("case");
            var TK_WHILE = ToTerm("while");
            var TK_DO = ToTerm("do");
            var TK_REPEAT = ToTerm("repeat");
            var TK_UNTIL = ToTerm("until");
            var TK_FOR = ToTerm("for");
            var TK_BREAK = ToTerm("break");
            var TK_CONTINUE = ToTerm("continue");

            RegisterOperators(1, TK_IGUAL,TK_DIFERENTE,TK_MAY,TK_MAYIGUAL,TK_MEN,TK_MENIGUAL);
            RegisterOperators(2, TK_SUM, TK_RES, TK_OR);
            RegisterOperators(3, TK_MUL, TK_DIV, TK_MOD, TK_AND);
            RegisterOperators(4, TK_NOT);

            NonGrammarTerminals.Add(comentarioLinea);
            NonGrammarTerminals.Add(comentarioBloque);
            NonGrammarTerminals.Add(comentarioMultiple);
            #endregion

            #region NoTerimnales
            NonTerminal inicio = new NonTerminal("inicio");
            NonTerminal NT_instrucciones = new NonTerminal("NT_instrucciones");
            NonTerminal NT_instruccion = new NonTerminal("NT_instruccion");

            //Instrucciones
            NonTerminal NT_program = new NonTerminal("NT_program");
            NonTerminal NT_declaracion = new NonTerminal("NT_declaracion");
            NonTerminal NT_type = new NonTerminal("NT_tipo");
            NonTerminal NT_funcion = new NonTerminal("NT_funcion");
            NonTerminal NT_operacion = new NonTerminal("NT_operacion");
            NonTerminal NT_asignacion = new NonTerminal("NT_asignacion");

            //Declaracion
            NonTerminal NT_tipo = new NonTerminal("NT_tipo");
            NonTerminal NT_listaVariables = new NonTerminal("NT_listaVariables");
            NonTerminal NT_inicializarVariable = new NonTerminal("NT_inicializarVariable");

            //Type
            NonTerminal NT_objeto = new NonTerminal("NT_objeto");

            //Objeto
            NonTerminal NT_declaracionObjeto = new NonTerminal("NT_declaracionObjeto");
            NonTerminal NT_camposObjeto = new NonTerminal("NT_camposObjeto");
            NonTerminal NT_campos = new NonTerminal("NT_campos");

            //Operaciones
            NonTerminal NT_operacionRelacional = new NonTerminal("NT_operacionRelacional");
            NonTerminal NT_expresion = new NonTerminal("NT_expresion");

            //Expresion
            NonTerminal NT_valor = new NonTerminal("NT_valor");
            NonTerminal NT_valores = new NonTerminal("NT_valores");
            #endregion

            #region Gramatica
            //Inicio Gramatica
            inicio.Rule = NT_instrucciones;
            inicio.ErrorRule = SyntaxError + TK_PYCOMA;

            //Instrucciones
            NT_instrucciones.Rule = NT_instrucciones + NT_instruccion
                | NT_instruccion
                | Empty;

            //Instruccion
            NT_instruccion.Rule = NT_program
                | NT_type
                | NT_asignacion
                | NT_declaracion;

            //Program
            NT_program.Rule = TK_PROGRAM + IDENTIFICADOR + TK_PYCOMA;

            //Declaracion
            NT_declaracion.Rule = TK_CONST + IDENTIFICADOR + TK_IGUAL + NT_expresion + TK_PYCOMA
                | TK_VAR + NT_listaVariables + TK_DOSPUNTOS + NT_tipo + TK_PYCOMA
                | NT_inicializarVariable;

            //Inicializar Variable
            NT_inicializarVariable.Rule = TK_VAR + IDENTIFICADOR + TK_DOSPUNTOS + NT_tipo + TK_IGUAL+ NT_expresion+ TK_PYCOMA;

            //Lista de Variables
            NT_listaVariables.Rule = NT_listaVariables + TK_COMA + IDENTIFICADOR
                | IDENTIFICADOR;

            //Asignacion
            NT_asignacion.Rule = IDENTIFICADOR + TK_IGUALAR + NT_expresion + TK_PYCOMA
                | IDENTIFICADOR + TK_PUNTO + IDENTIFICADOR + TK_IGUAL + NT_expresion + TK_PYCOMA;

            //Tipo
            NT_tipo.Rule = TK_STRING
                | TK_INTEGER
                | TK_REAL
                | TK_BOOLEAN
                | TK_OBJECT
                | IDENTIFICADOR;

            //Type
            NT_type.Rule = TK_TYPE + NT_objeto;

            //Objeto 
            NT_objeto.Rule = NT_declaracionObjeto + NT_campos + TK_END + TK_PYCOMA;

            //Campos
            NT_campos.Rule = NT_campos + NT_camposObjeto
                | NT_camposObjeto;

            //Campos Objeto
            NT_camposObjeto.Rule = TK_VAR + NT_listaVariables + TK_DOSPUNTOS + NT_tipo + TK_PYCOMA;

            //Declaracion Objeto
            NT_declaracionObjeto.Rule = IDENTIFICADOR + TK_IGUAL + TK_OBJECT + TK_PYCOMA;

            //Operacion Logica
            NT_operacion.Rule = NT_operacion + TK_AND + NT_operacion
                | NT_operacion + TK_OR + NT_operacion
                | TK_NOT + NT_operacion
                | TK_PARIZQ + NT_operacion + TK_PARDER
                | NT_operacionRelacional;

            //Operacion Relacional
            NT_operacionRelacional.Rule = NT_expresion + TK_IGUAL + NT_expresion
                | NT_expresion + TK_DIFERENTE + NT_expresion
                | NT_expresion + TK_MAY + NT_expresion
                | NT_expresion + TK_MEN + NT_expresion
                | NT_expresion + TK_MAYIGUAL + NT_expresion
                | NT_expresion + TK_MENIGUAL + NT_expresion
                | TK_PARIZQ + NT_operacionRelacional + TK_PARDER
                | NT_expresion;

            //Expresion
            NT_expresion.Rule = NT_expresion + TK_SUM + NT_expresion
                | NT_expresion + TK_RES + NT_expresion
                | NT_expresion + TK_MUL + NT_expresion
                | NT_expresion + TK_DIV + NT_expresion
                | NT_expresion + TK_MOD + NT_expresion
                | TK_RES + NT_expresion
                | TK_PARIZQ + NT_expresion + TK_PARDER
                | IDENTIFICADOR + TK_PARIZQ + TK_PARDER
                | IDENTIFICADOR + TK_PARIZQ + NT_valores + TK_PARDER
                | NT_valor;

            //Valores
            NT_valores.Rule = NT_valores + TK_COMA + NT_expresion
                | NT_expresion;

            //Valor
            NT_valor.Rule = NUMERO
                | DECIMAL
                | CADENA
                | TK_TRUE
                | TK_FALSE
                | IDENTIFICADOR;

            #endregion

            #region Preferencias
            this.Root = inicio;
            #endregion
        }
    }
}
