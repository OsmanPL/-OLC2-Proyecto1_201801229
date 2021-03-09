using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace _OLC2_Proyecto1_201801229.Interfaces
{
    class Operacion : Instruccion
    {
        public enum Tipo_operacion
        {
            SUMA,
            CONCAT,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            MODULAR,
            NEGATIVO,
            NUMERO,
            IDENTIFICADOR,
            CADENA,
            DECIMAL,
            MAYOR_QUE,
            MENOR_QUE,
            AND,
            OR,
            NOT,
            MAYOR_IGUAL_QUE,
            MENOR_IGUAL_QUE,
            IGUAL,
            DIFERENTE,
            LLAMADAPROCEDIMIENTO,
            LLAMADAFUNCION,
            BOOLEAN,
            OBJECT,
            ARRAY,
            TYPE
        }

        private Tipo_operacion tipo;
        private String id;
        private Operacion operadorIzq;
        private Operacion operadorDer;
        private Object valor;
        private LinkedList<Operacion> valores;
        private String type;

        internal Tipo_operacion Tipo { get => tipo; set => tipo = value; }

        public Operacion()
        {

        }
        public Operacion(String id, String type, Tipo_operacion tipo)
        {
            this.id = id;
            this.type = type;
            this.tipo = tipo;
        }

        public Operacion(String id, Operacion operadorDer, Tipo_operacion tipo)
        {
            this.id = id;
            this.operadorDer = operadorDer;
            this.tipo = tipo;
        }
        public Operacion(Operacion operadorIzq, Operacion operadorDer, Tipo_operacion tipo)
        {
            this.Tipo = tipo;
            this.operadorIzq = operadorIzq;
            this.operadorDer = operadorDer;
        }         
        public Operacion(Operacion operadorIzq, Tipo_operacion tipo)
        {
            this.Tipo = tipo;
            this.operadorIzq = operadorIzq;
        }
        public Operacion(String id, Tipo_operacion tipo)
        {
            this.id = id;
            this.Tipo = tipo;
        }
        public Operacion(String id, LinkedList<Operacion> valor,Tipo_operacion tipo)
        {
            this.id = id;
            this.valores = valor;
            this.Tipo = tipo;
        }
        public Operacion(Object valor, Tipo_operacion tipo)
        {
            this.valor = valor;
            this.Tipo = tipo;
        }


        public Object ejecutar(TablaSimbolos ts) {
            Object valorIzquierdo;
            Object valorDerecho;
            switch (tipo)
            {
                //Operaciones Logicas
                case Tipo_operacion.AND:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Boolean && valorDerecho is Boolean)
                        {
                            return (Boolean)valorIzquierdo && (Boolean)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.OR:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Boolean && valorDerecho is Boolean)
                        {
                            return (Boolean)valorIzquierdo || (Boolean)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.NOT:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    if (valorIzquierdo != null)
                    {
                        if (valorIzquierdo is Boolean)
                        {
                            return !(Boolean)valorIzquierdo ;
                        }
                    }
                    return null;

                //Operaciones Relacionales
                case Tipo_operacion.MAYOR_IGUAL_QUE:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo >= (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.MAYOR_QUE:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo > (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.MENOR_IGUAL_QUE:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo <= (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.MENOR_QUE:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo < (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.IGUAL:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        return (operadorIzq.ejecutar(ts)).Equals((operadorDer.ejecutar(ts)));
                    }
                    return null;
                case Tipo_operacion.DIFERENTE:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo != (Double)valorDerecho;
                        }
                    }
                    return null;

                //Operaciones Aritmeticaas
                case Tipo_operacion.SUMA:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if(valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo + (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.RESTA:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo - (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.MULTIPLICACION:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo * (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.DIVISION:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo / (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.MODULAR:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    valorDerecho = operadorDer.ejecutar(ts);
                    if (valorIzquierdo != null && valorDerecho != null)
                    {
                        if (valorIzquierdo is Double && valorDerecho is Double)
                        {
                            return (Double)valorIzquierdo % (Double)valorDerecho;
                        }
                    }
                    return null;
                case Tipo_operacion.NEGATIVO:
                    valorIzquierdo = operadorIzq.ejecutar(ts);
                    if (valorIzquierdo != null )
                    {
                        if (valorIzquierdo is Double )
                        {
                            return (Double)valorIzquierdo * -1;
                        }
                    }
                    return null;
                    

                //Operacion Concatenar
                case Tipo_operacion.CONCAT:
                    return operadorIzq.ejecutar(ts).ToString() + operadorDer.ejecutar(ts).ToString();

                //Valores
                case Tipo_operacion.NUMERO:
                    try
                    {
                        return Double.Parse(valor.ToString());
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo integer","Error");
                        return null;
                    }
                case Tipo_operacion.DECIMAL:
                    try
                    {
                        return Double.Parse(valor.ToString());
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }
                case Tipo_operacion.BOOLEAN:
                    try
                    {
                        return Boolean.Parse(valor.ToString());
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo boolean", "Error");
                        return null;
                    }
                case Tipo_operacion.CADENA:
                    try
                    {
                        return valor.ToString();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }
                case Tipo_operacion.OBJECT:
                    try
                    {
                        return valor;
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }
                case Tipo_operacion.IDENTIFICADOR:
                    try
                    {
                        Simbolo sim = ts.getSimbolo(valor.ToString());
                        switch (sim.Tipo)
                        {
                            case Simbolo.TipoDato.INTEGER:
                                return Double.Parse(ts.getValor(valor.ToString()).ToString());
                            case Simbolo.TipoDato.OBJECT:
                                return ts.getValor(valor.ToString());
                            case Simbolo.TipoDato.STRING:
                                return ts.getValor(valor.ToString()).ToString();
                            case Simbolo.TipoDato.REAL:
                                return Double.Parse(ts.getValor(valor.ToString()).ToString());
                            case Simbolo.TipoDato.BOOLEAN:
                                return Boolean.Parse(ts.getValor(valor.ToString()).ToString());
                            default:
                                return null;
                        }
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }
                case Tipo_operacion.ARRAY:
                    try
                    {
                        Object arr = ts.getValor(id);
                        ArrayPascal arreglo = (ArrayPascal)arr;
                        return arreglo.buscarValor(int.Parse(operadorDer.ejecutar(ts).ToString()));
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }
                case Tipo_operacion.TYPE:
                    try
                    {
                        Object arr = ts.getValor(id);
                        InstruccionType arreglo = (InstruccionType)arr;
                        return arreglo.buscarValor(type,ts);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("No es tipo real", "Error");
                        return null;
                    }

            }
            return null;
        }
    }
}
