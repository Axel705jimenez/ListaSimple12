using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ListaSimpleAlumno
{
    class Lista
    {
        private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }
        public Lista()
        {
            head = null;
        }
        public void Agregar(Nodo n)
        {
            if (head == null)
            {
                head = n;
                return;
            }
            if (n.Numero < head.Numero)
            {
                n.Siguiente = head;
                head = n;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (n.Numero < h.Siguiente.Numero)
                {
                    break;
                }
                h = h.Siguiente;
            }
            n.Siguiente = h.Siguiente;
            h.Siguiente = n;
        }
        public void Eliminar(int d)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head = head.Siguiente;
                return;
            }
            Nodo h = Head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    break;
                }
                h = h.Siguiente;
            }
            if (h.Siguiente != null)
            {
                h.Siguiente = h.Siguiente.Siguiente;
            }
        }

        public void Mostrar(ListBox lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            while (h != null)
            {
                lista.Items.Add(h.Numero + " " + h.Matricula + " " + h.Nombre + " " + h.APaterno+ " " + h.AMaterno + " " + h.Carrera);
                h = h.Siguiente;
            }
        }
        
        public bool Buscar(int d, ref Nodo b)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Numero == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    b = h.Siguiente;
                    return true;
                }
                h = h.Siguiente;
            }
            return false;
        }
        public void Modificar(int d, string m, string n, string ap, string am, string c)
        {
            if (head == null)
            {
                return;
            }
            if (head.Numero == d)
            {
                head.Matricula = m;
                head.Nombre = n;
                head.APaterno = ap;
                head.AMaterno = am;
                head.Carrera = c;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    h.Siguiente.Matricula = m;
                    h.Siguiente.Nombre = n;
                    h.Siguiente.APaterno = ap;
                    h.Siguiente.AMaterno = am;
                    h.Siguiente.Carrera = c;
                    return;
                }
                h = h.Siguiente;
            }
            return;
        }
        public void Guardar(string nombreArchivo)
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            nombreArchivo = "testListaSimple";
            string path = @"C:\" + nombreArchivo + ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.Numero + "-" + h.Matricula + "-" + h.Nombre + "-" + h.APaterno +
                        "-" + h.AMaterno + "-" + h.Carrera + "-" + h.Calificacion +"-");
                    h = h.Siguiente;
                } while (h != null);
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
            Nodo h = head;
            nombreArchivo = "testListaSimple";
            string[] lineas = File.ReadAllLines(@"C:\" + nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int numero = int.Parse(datos[0]);
                string matricula = datos[1];
                string nombre = datos[2];
                string apaterno = datos[3];
                string aMaterno = datos[4];
                string carrera = datos[5];
                int calificacion = int.Parse(datos[6]);
                Nodo n = new Nodo(numero, matricula, nombre, apaterno, aMaterno, carrera, calificacion);
                Agregar(n);
            }
        }

        public override string ToString()
        {
            string listaTexto = "";
            Nodo h = head;
            while (h != null)
            {
                listaTexto += h.ToString() + " ";
                h = h.Siguiente;
            }
            return listaTexto;
        }
    }
}
