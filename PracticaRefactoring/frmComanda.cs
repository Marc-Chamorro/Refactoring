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

        List<Detall> Cistella = new List<Detall>();
        Comanda comanda = new Comanda();
        string numComanda;
        DadesComanda DadesComanda = new DadesComanda();
        int contador = 0;
        bool novaComanda = false;


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
            double importBrut = comanda.FerCalculIRound(Cistella, "Brut", cmbClients.Text);
            lblBrut.Text = importBrut.ToString();
            DadesComanda.ImportBrut = importBrut.ToString();
        }

        private void btnIVA_Click(object sender, EventArgs e)
        {
            double iva = comanda.FerCalculIRound(Cistella, "Iva", cmbClients.Text);
            lblIva.Text = iva.ToString();
            DadesComanda.IVA = iva.ToString();
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            double despesa = comanda.FerCalculIRound(Cistella, "Despesa", cmbClients.Text);
            lblDespesa.Text = despesa.ToString();
            DadesComanda.Despesa = despesa.ToString();
        }


        private void btnDescompte_Click(object sender, EventArgs e)
        {
            double descompte = comanda.FerCalculIRound(Cistella, "Descompte", cmbClients.Text);
            lbldescompte.Text = descompte.ToString();
            DadesComanda.Descompte = descompte.ToString();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            double importNet = comanda.FerCalculIRound(Cistella, "Total", cmbClients.Text);
            lblTotal.Text = importNet.ToString();
            grpResum.Visible = true;
        }

        private void btnComanda_Click(object sender, EventArgs e)
        {
            novaComanda = true;
            contador = contador  + 1;
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
