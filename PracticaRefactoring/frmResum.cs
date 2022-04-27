using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaRefactoring
{
    public partial class frmResum : Form
    {
        public frmResum()
        {
            InitializeComponent();
        }

        private string zona;
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private List<Detall> detall;
        public List<Detall> Detall
        {
            get { return detall; }
            set { detall = value; }
        }

        private DadesComanda dades;
        public DadesComanda Dades
        {
            get { return dades; }
            set { dades = value; }
        }

        private void frmResum_Load(object sender, EventArgs e)
        {
            if (zona=="Insular")
            {
                lblObservacions.Text = "Observacions: Pendent de confiormació des de la central";
            }

            lblBrut.Text = dades.ImportBrut;
            lblIva.Text = dades.IVA;
            lblDespesa.Text = dades.Despesa;
            lbldescompte.Text = dades.Descompte;

            lblComanda.Text = dades.ComandaNum;
            lblClient.Text = dades.Client;
            lblestat.Text = dades.Estat;

            Comanda cmd = new Comanda();
            lblTotal.Text = cmd.CalcularPreuTotal(dades).ToString();

            dtgProductes.DataSource = detall;
        }
    }
}
