using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    public partial class Home : Form
    {
        // PASSWORD
        public static String realPassword;
        // Invoice Header
        public static String invoiceHeader;

        public static Home Instance;

        private static UserControl mainPanel;
        private static HomeControl homeControl;

        private static ProductEntryControl productEntryControl;
        private static DynamicProductEntryControl _dynamicProductEntryControl;

        public static UserControl[] qcControls = new UserControl[4];
        public static TraceabilityControl[] traceabilityControls = new TraceabilityControl[4];
        public static GenericEfficiencyControl[] efficiencyControls = new GenericEfficiencyControl[4];

        private static ChocolateSetupControl chocolateSetupControl;
        private static ChocolateShutdownControl chocolateShutdownControl;
        private static JamSetupControl jamSetupControl;
        private static JamShutdownControl jamShutdownControl;
        private static BBQSetupControl bbqSetupControl;
        private static BBQShutdownControl bbqShutdownControl;

        private static SearchControl searchControl;
        private static InventoryControl inventoryControl;
        private static PastInventoriesControl pastInventoriesControl;
        private static RecipeControl recipeControl;
        public static InvoicingControl invoiceControl;
        private static InvoiceSearch pastInvoices;

        private static Stack<UserControl> _controlStack; 

        public static readonly Image Document = Image.FromFile("../../IconImages/document.png");
        public static readonly Image BlankDocument = Image.FromFile("../../IconImages/blankDocument.png");
        public static readonly Image XMark = Image.FromFile("../../IconImages/x_mark.png");
        public static readonly Image CheckMark = Image.FromFile("../../IconImages/check_mark.png");

        public static Point ControlStartingPoint;

        public Home()
        {
            InitializeComponent();

            Instance = this;
            _controlStack = new Stack<UserControl>();

            ReadPreferencesFromFile();

            ControlStartingPoint = new Point(SidePanel.Right, TopPanel.Bottom);
            // Home Display
            homeControl = new HomeControl();
            homeControl.Location = ControlStartingPoint;
            homeControl.Visible = true;

            // Product Entry
            productEntryControl = new ProductEntryControl(this);
            productEntryControl.Location = ControlStartingPoint;
            productEntryControl.Visible = false;

            _dynamicProductEntryControl = new DynamicProductEntryControl();
            _dynamicProductEntryControl.Location = ControlStartingPoint;
            _dynamicProductEntryControl.Visible = false;

            // Setup/Shutdown Controls
            // General Setup
            chocolateSetupControl = new ChocolateSetupControl(this);
            chocolateSetupControl.Location = ControlStartingPoint;
            chocolateSetupControl.Visible = false;
            // Chocolate Shutdown
            chocolateShutdownControl = new ChocolateShutdownControl(this);
            chocolateShutdownControl.Location = ControlStartingPoint;
            chocolateShutdownControl.Visible = false;
            // Jam Setup
            jamSetupControl = new JamSetupControl(this);
            jamSetupControl.Location = ControlStartingPoint;
            jamSetupControl.Visible = false;
            // Jam Shutdown
            jamShutdownControl = new JamShutdownControl(this);
            jamShutdownControl.Location = ControlStartingPoint;
            jamShutdownControl.Visible = false;
            // BBQ Setup
            bbqSetupControl = new BBQSetupControl(this);
            bbqSetupControl.Location = ControlStartingPoint;
            bbqSetupControl.Visible = false;
            // BBQ Shutdown
            bbqShutdownControl = new BBQShutdownControl(this);
            bbqShutdownControl.Location = ControlStartingPoint;
            bbqShutdownControl.Visible = false;


            // Controls
            for (int row = 0; row < traceabilityControls.Length; row++)
            {
                traceabilityControls[row] = null;
            }

            // Search
            searchControl = new SearchControl(this);
            searchControl.Location = ControlStartingPoint;
            searchControl.Visible = false;

            // Recipes
            recipeControl = new RecipeControl(this);
            recipeControl.Location = ControlStartingPoint;
            recipeControl.Visible = false;

            // Inventory
            inventoryControl = new InventoryControl(this);
            inventoryControl.Location = ControlStartingPoint;
            inventoryControl.Visible = false;
            pastInventoriesControl = new PastInventoriesControl();
            pastInventoriesControl.Location = ControlStartingPoint;
            pastInventoriesControl.Visible = false;

            // Invoicing
            invoiceControl = new InvoicingControl(this);
            invoiceControl.Location = ControlStartingPoint;
            invoiceControl.Visible = false;

            // Invoice Search
            pastInvoices = new InvoiceSearch(this);
            pastInvoices.Location = ControlStartingPoint;
            pastInvoices.Visible = false;

            // End
            mainPanel = homeControl;
            this.Controls.Add(homeControl);
            this.Controls.Add(searchControl);
            this.Controls.Add(recipeControl);
            this.Controls.Add(productEntryControl);
            this.Controls.Add(inventoryControl);
            this.Controls.Add(pastInventoriesControl);
            this.Controls.Add(invoiceControl);
            this.Controls.Add(pastInvoices);

            // Setup/Shutdown
            this.Controls.Add(chocolateSetupControl);
            this.Controls.Add(chocolateShutdownControl);
            this.Controls.Add(jamSetupControl);
            this.Controls.Add(jamShutdownControl);
            this.Controls.Add(bbqSetupControl);
            this.Controls.Add(bbqShutdownControl);
        }

        private void ReadPreferencesFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../DatabaseObjects/Preferences.txt"))
                {
                    String preferencesData = sr.ReadToEnd();
                    int from = preferencesData.IndexOf(":") + 1;
                    int to = preferencesData.LastIndexOf(":");
                    int headerFrom = preferencesData.IndexOf("-") + 1;
                    realPassword = preferencesData.Substring(from, to - from);
                    invoiceHeader = preferencesData.Substring(headerFrom, preferencesData.Length - headerFrom);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public static void overwritePreferencesFile()
        {
            String text = "Password:" + realPassword + ":Header-" + invoiceHeader;
            System.IO.File.WriteAllText("../../DatabaseObjects/Preferences.txt", text);
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Home":
                    changeViewToHome();
                    break;
                case "Product Entry":
                    ChangeMainViewControl(_dynamicProductEntryControl);
                    //changeViewToProductEntry();
                    break;
                case "Search":
                    changeViewToSearch();
                    break;
                case "Recipes":
                    PasswordProtectWindow ppw = new PasswordProtectWindow();
                    ppw.ShowDialog();
                    break;
                case "Quality Forms":
                    new QualityWindow(this).ShowDialog();
                    break;
                case "Preferences":
                    PropertiesWindow propertiesWindow = new PropertiesWindow(this);
                    propertiesWindow.StartPosition = FormStartPosition.CenterScreen;
                    propertiesWindow.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        /**
         * Changes the main panel to the previous control that ChangeMainViewControl was called on.
         */
        public static void ChangeToPreviousControl()
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = _controlStack.Pop();
            mainPanel.Visible = true;
        }

        /**
         * Changes the main panel to the input control.
         */
        public static void ChangeMainViewControl(UserControl control)
        {
            if (!Instance.Controls.Contains(control))
                Instance.Controls.Add(control);
            if (mainPanel != null)
                mainPanel.Visible = false;
            _controlStack.Push(mainPanel);
            mainPanel = control;
            mainPanel.Visible = true;
        }

        /**
         * Pre-condition, view must be between 1-4!
         * should be the corresponding row to traceability view
         * */
        public static void changeViewToTraceability(int view)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = traceabilityControls[view];
            mainPanel.Visible = true;
        }

        public static void changeViewToHome()
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = homeControl;
            mainPanel.Visible = true;
        }
        
        /**
         * Pre-condition, view must be between 1-4!
         * should be the corresponding row to efficiency view
         * */
        public static void changeViewToEfficiency(int pane)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = efficiencyControls[pane];
            mainPanel.Visible = true;
        }

        public static void changeViewToProductEntry()
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = productEntryControl;
            mainPanel.Visible = true;
        }

        public static void changeViewToSearch()
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = searchControl;
            mainPanel.Visible = true;
        }

        public static void changeViewToRecipes()
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = recipeControl;
            mainPanel.Visible = true;
        }

        public void chocolateSetupTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = chocolateSetupControl;
            mainPanel.Visible = true;
        }

        private void chocolateShutdownTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = chocolateShutdownControl;
            mainPanel.Visible = true;
        }

        private void jamSetupTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = jamSetupControl;
            mainPanel.Visible = true;
        }

        private void jamShutdownTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = jamShutdownControl;
            mainPanel.Visible = true;
        }

        private void bbqSetupTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = bbqSetupControl;
            mainPanel.Visible = true;
        }

        private void bbqShutdownTab_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = bbqShutdownControl;
            mainPanel.Visible = true;
        }

        public void setupQC(int row, UserControl qc)
        {
            qcControls[row] = qc;
            qcControls[row].Location = ControlStartingPoint;
            qcControls[row].Visible = false;
            this.Controls.Add(qc);
        }

        public static void changeViewToQualityRow(int row)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = qcControls[row];
            mainPanel.Visible = true;
        }

        public void refreshRecipeControl()
        {
            this.Controls.Remove(recipeControl);
            recipeControl = new RecipeControl(this);
            recipeControl.Location = ControlStartingPoint;
            recipeControl.Visible = false;
            this.Controls.Add(recipeControl);
        }

        public void refreshProductEntry()
        {
            this.Controls.Remove(productEntryControl);
            productEntryControl = new ProductEntryControl(this);
            productEntryControl.Location = ControlStartingPoint;
            productEntryControl.Visible = false;
            this.Controls.Add(productEntryControl);
        }

        public void refreshInventory()
        {
            this.Controls.Remove(inventoryControl);
            inventoryControl = new InventoryControl(this);
            inventoryControl.Location = ControlStartingPoint;
            inventoryControl.Visible = false;
            this.Controls.Add(inventoryControl);
            runningInventoryMenuItem_Click(null, null);
        }

        public void refreshPastInventory()
        {
            this.Controls.Remove(pastInventoriesControl);
            pastInventoriesControl = new PastInventoriesControl();
            pastInventoriesControl.Location = ControlStartingPoint;
            pastInventoriesControl.Visible = false;
            this.Controls.Add(pastInventoriesControl);
        }

        public void refreshInvoice()
        {
            this.Controls.Remove(invoiceControl);
            invoiceControl = new InvoicingControl(this);
            invoiceControl.Location = ControlStartingPoint;
            invoiceControl.Visible = false;
            this.Controls.Add(invoiceControl);
        }

        public void refreshChecklist(UserControl checklist, String type)
        {
            this.Controls.Remove(checklist);
            switch (type)
            {
                case ("bbqsetup"):
                    bbqSetupControl = new BBQSetupControl(this);
                    bbqSetupControl.Location = ControlStartingPoint;
                    bbqSetupControl.Visible = false;
                    this.Controls.Add(bbqSetupControl);
                    break;
                case ("bbqshutdown"):
                    bbqShutdownControl = new BBQShutdownControl(this);
                    bbqShutdownControl.Location = ControlStartingPoint;
                    bbqShutdownControl.Visible = false;
                    this.Controls.Add(bbqShutdownControl);
                    break;
                case ("chocolatesetup"):
                    chocolateSetupControl = new ChocolateSetupControl(this);
                    chocolateSetupControl.Location = ControlStartingPoint;
                    chocolateSetupControl.Visible = false;
                    this.Controls.Add(chocolateSetupControl);
                    break;
                case ("chocolateshutdown"):
                    chocolateShutdownControl = new ChocolateShutdownControl(this);
                    chocolateShutdownControl.Location = ControlStartingPoint;
                    chocolateShutdownControl.Visible = false;
                    this.Controls.Add(chocolateShutdownControl);
                    break;
                case ("jamsetup"):
                    jamSetupControl = new JamSetupControl(this);
                    jamSetupControl.Location = ControlStartingPoint;
                    jamSetupControl.Visible = false;
                    this.Controls.Add(jamSetupControl);
                    break;
                case ("jamshutdown"):
                    jamShutdownControl = new JamShutdownControl(this);
                    jamShutdownControl.Location = ControlStartingPoint;
                    jamShutdownControl.Visible = false;
                    this.Controls.Add(jamShutdownControl);
                    break;
                default:
                    break;
            }
            
            changeViewToHome();
        }

        private void runningInventoryMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = inventoryControl;
            mainPanel.Visible = true;
        }

        private void pastInventoriesMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            refreshPastInventory();
            mainPanel = pastInventoriesControl;
            mainPanel.Visible = true;
        }

        public static void productChanged(Home home, Recipe recipe, int view)
        {
            if (qcControls[view] != null)
                home.Controls.Remove(qcControls[view]);
            if (recipe.QualityControlId != 1)
            {
                if (recipe.QualityControlId > Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    qcControls[view] = new GenericQualityControl(recipe);
                }
                else if (recipe.QualityControlId == Library.CHOCOLATE_QUALITY_CONTROL)
                {
                    qcControls[view] = new ChocolateQualityControl();
                }
                qcControls[view].Location = new Point(home.SidePanel.Right, home.TopPanel.Bottom);
                qcControls[view].Visible = false;
                home.Controls.Add(qcControls[view]);
            }
            if (efficiencyControls[view] != null)
                home.Controls.Remove(efficiencyControls[view]);
            efficiencyControls[view] = new GenericEfficiencyControl(recipe);
            efficiencyControls[view].Location = new Point(home.SidePanel.Right, home.TopPanel.Bottom);
            efficiencyControls[view].Visible = false;
            home.Controls.Add(efficiencyControls[view]);

        }

        public void newInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = invoiceControl;
            mainPanel.Visible = true;
        }

        private void customerManagement_Click(object sender, EventArgs e)
        {
            CustomerManager manager = new CustomerManager();
            manager.ShowDialog();
            refreshInvoice();
        }

        private void pastInvoices_Click(object sender, EventArgs e)
        {
            if (mainPanel != null)
                mainPanel.Visible = false;
            mainPanel = pastInvoices;
            mainPanel.Visible = true;
        }
    }
}
