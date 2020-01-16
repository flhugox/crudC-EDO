using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudWindowsForm.Models;

namespace CrudWindowsForm.Presentation
{
    public partial class FrmTabla : Form
    {
        public int? id;
        tabla oTabla = null;
        public FrmTabla(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
                CargaDatos();
        }

        private void CargaDatos()
        {
            using (CrudEntities db = new CrudEntities())
            {
                oTabla = db.tabla.Find(id);
                txtCorreo.Text = oTabla.correo;
                txtNombre.Text = oTabla.nombre;
                dtpFechaNacimiento.Value = oTabla.fecha_nacimiento;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrudEntities db= new CrudEntities())
            {
                if(id==null)
                    oTabla = new tabla();

                oTabla.nombre = txtNombre.Text;
                oTabla.correo = txtCorreo.Text;
                oTabla.fecha_nacimiento = dtpFechaNacimiento.Value;

                if(id==null)
                    db.tabla.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();

                this.Close();
            }
        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {

        }
    }
}
