using System.Windows.Forms;

namespace Vatsim.Core
{
  internal class VatSpyAppContext : ApplicationContext
  {
    private readonly MainForm mMainForm;

    public VatSpyAppContext(IFormFactory formFactory)
    {
      this.mMainForm = formFactory.CreateMainForm();
      this.mMainForm.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
      formFactory.CreateStartupForm().Show();
    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) => this.ExitThread();
  }
}
