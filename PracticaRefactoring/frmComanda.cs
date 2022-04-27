using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PracticaRefactoring
{
    public partial class frmComanda : Form
    {
        private string representant;
        public string Representant
        {
            get { return representant; }
            set { representant = value; }
        }

        private string zona;

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private Comanda comanda = new Comanda();
        private DadesComanda DadesComanda = new DadesComanda();

       

        private List<Detall> Cistella = new List<Detall>();

        private string numComanda;
        private int contador = 0;
        private bool novaComanda = false;


        public frmComanda()
        {
            InitializeComponent();
        }


        private void btnDetall_Click(object sender, EventArgs e)
        {
            Detall compra = new Detall();
            compra.Producte = cmbProductes.Text;
            compra.preu = double.Parse(txtPreu.Text);
            compra.quantitat = int.Parse(txtQuantitat.Text);
            Cistella.Add(compra);

            dtgProductes.DataSource = null;
            dtgProductes.DataSource = Cistella;

            txtPreu.Text = "";
            txtQuantitat.Text = "";
        }

        private void btnBrut_Click(object sender, EventArgs e)
        {
            double importBrut = 0.0;
            importBrut = comanda.calcBrut(Cistella,cmbClients.Text);
            importBrut = Math.Round(importBrut, 2, MidpointRounding.AwayFromZero);
            lblBrut.Text = importBrut.ToString();
            DadesComanda.ImportBrut = importBrut.ToString();
        }

        private void btnIVA_Click(object sender, EventArgs e)
        {
            double iva = 0.0;
            iva = comanda.calcIva(Cistella, cmbClients.Text);
            iva = Math.Round(iva, 2, MidpointRounding.AwayFromZero);
            lblIva.Text = iva.ToString();
            DadesComanda.IVA = iva.ToString();
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            double despesa=0.0;
            despesa = comanda.calcDespesa(Cistella, cmbClients.Text);
            despesa = Math.Round(despesa, 2, MidpointRounding.AwayFromZero);
            lblDespesa.Text = despesa.ToString();
            DadesComanda.Despesa = despesa.ToString();
        }


        private void btnDescompte_Click(object sender, EventArgs e)
        {
            double descompte = 0.0;
            descompte = comanda.calcDescompte(Cistella, cmbClients.Text);
            descompte = Math.Round(descompte, 2, MidpointRounding.AwayFromZero);
            lbldescompte.Text = descompte.ToString();
            DadesComanda.Descompte = descompte.ToString();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            double importNet = 0.0;
            importNet = comanda.calcTotal(Cistella, cmbClients.Text);
            importNet = Math.Round(importNet, 2, MidpointRounding.AwayFromZero);
            lblTotal.Text = importNet.ToString();
            //podemFinalitzar = true;
            grpResum.Visible = true;
        }

        private void btnComanda_Click(object sender, EventArgs e)
        {
            novaComanda = true;
            contador++;
            DadesComanda = new DadesComanda();

            int dia = DateTime.Today.DayOfYear;
            numComanda = dia.ToString() + "-" + contador.ToString();
            lblComanda.Text = numComanda;
            DadesComanda.ComandaNum = numComanda;
            DadesComanda.Client = cmbClients.Text;
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(novaComanda)
                DadesComanda.Client = cmbClients.Text;
        }

        private void cmbEstat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbEstat.SelectedIndex)
            {
                case 0:
                    DadesComanda.Estat = "En espera";
                    break;
                case 1:
                    DadesComanda.Estat = "Retinguda";
                    break;
                case 2:
                    DadesComanda.Estat = "Condicionada";
                    break;
                default:
                    DadesComanda.Estat = "Confirmada";
                    break;
            }
        }

        private void btnResum_Click(object sender, EventArgs e)
        {
            frmResum frm = new frmResum();
            frm.Zona = zona;
            frm.Detall = Cistella;
            frm.Dades = DadesComanda;

            frm.Show();
        }

        private void frmComanda_Load(object sender, EventArgs e)
        {
            lblRepresentant.Text = Representant;
        }
    }
}
