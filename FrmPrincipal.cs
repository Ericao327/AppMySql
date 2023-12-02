using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMySql
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            List<Aluno> alunos = aluno.listaaluno();
            dgvAluno.DataSource = alunos;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno aluno = new Aluno();
                if (aluno.RegistroRepetido(txtNom.Text, txtCelular.Text) == true)
                {
                    MessageBox.Show("Aluno já existe em nossa base de dados!", "Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNom.Text = "";
                    txtCelular.Text = "";
                    textBox4.Text = "";
                    return;
                }
                else
                {
                    aluno.Inserir(txtNom.Text, txtCelular.Text, textBox4.Text);
                    MessageBox.Show("Aluno inserido com sucesso!", "Inserir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Aluno> alunos = aluno.listaaluno();
                    dgvAluno.DataSource = alunos;
                    txtNom.Text = "";
                    txtCelular.Text = "";
                    textBox4.Text = "";
                    this.txtNom.Focus();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Aluno aluno = new Aluno();
                aluno.Localizar(id);
                txtNom.Text = aluno.nome;
                txtCelular.Text = aluno.celular;
                textBox4.Text= aluno.serie;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Aluno aluno = new Aluno();
                aluno.Atualizar(id, txtNom.Text, txtCelular.Text, textBox4.Text);
                MessageBox.Show("Aluno atualizado com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Aluno> alunos = aluno.listaaluno();
                dgvAluno.DataSource = alunos;
                txtNom.Text = "";
                txtCelular.Text = "";
                textBox4.Text = "";
                txtId.Text = "";
                this.txtNom.Focus();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text.Trim());
                Aluno aluno = new Aluno();
                aluno.Excluir(id);
                MessageBox.Show("Aluno excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Aluno> alunos = aluno.listaaluno();
                dgvAluno.DataSource = alunos;
                txtNom.Text = "";
                txtCelular.Text = "";
                textBox4.Text = "";
                txtId.Text = "";
                this.txtNom.Focus();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnTurma_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                Aluno aluno = new Aluno();
                aluno.Turma(id);
                MessageBox.Show("Aluno selecionado para a turma com sucesso!", "Seleção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Aluno> alunos = aluno.listaaluno();
                dgvAluno.DataSource = alunos;
                txtNom.Text = "";
                txtCelular.Text = "";
                textBox4.Text = "";
                txtId.Text = "";
                this.txtNom.Focus();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvAluno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAluno.Rows[e.RowIndex];
                this.dgvAluno.Rows[e.RowIndex].Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNom.Text = row.Cells[1].Value.ToString();
                txtCelular.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
        }
    }
}
