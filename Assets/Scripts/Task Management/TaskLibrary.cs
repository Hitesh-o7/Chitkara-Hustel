using System.Collections.Generic;

public static class TaskLibrary
{
    // Define a list of tasks for each location
    public static List<string> DeansOfficeTasks = new List<string>
    {
        "Get the file from Dean's office.",
        "Get the report from Dean's office.",
        "Retrieve the folder from Dean's office.",
        "Fetch the office supplies from Dean's office.",
        "Bring the Dean's personal calendar.",
        "Collect the urgent papers from Dean's office.",
        "Grab the letter from the secretary in Dean's office.",
        "Retrieve the laptop charger from Dean's office.",
        "Pick up the staff meeting minutes from Dean's office.",
        "Bring the coffee mug from Dean's office."
    };

    public static List<string> BabbageBlockTasks = new List<string>
    {
        "Get the financial report from Babbage Block.",
        "Bring the ledger book from Babbage Block.",
        "Retrieve the stamped tax documents from Babbage Block.",
        "Deliver the pay slip files from Babbage Block.",
        "Get the invoice papers from Babbage Block.",
        "Bring the calculator from Babbage Block.",
        "Pick up the invoice book from Babbage Block.",
        "Fetch the tax return file from Babbage Block.",
        "Grab the payroll records from Babbage Block.",
        "Deliver the bank statements from Babbage Block."
    };

    public static List<string> StaffRoom1Tasks = new List<string>
    {
        "Fetch the register from Staff Room 1.",
        "Get the extra pens and notepads from Staff Room 1.",
        "Pick up the stack of papers from Staff Room 1.",
        "Bring the coffee pot from Staff Room 1.",
        "Retrieve the staff meeting agenda from Staff Room 1.",
        "Grab the photocopy of the latest presentation from Staff Room 1.",
        "Bring the stapler from Staff Room 1.",
        "Get the office jacket from Staff Room 1.",
        "Collect the water bottle from Staff Room 1.",
        "Bring the first aid kit from Staff Room 1."
    };

    public static List<string> NewtonBlockTasks = new List<string>
    {
        "Fetch the lab book from Newton Block.",
        "Retrieve the whiteboard marker from Newton Block.",
        "Pick up the broken mouse from Newton Block.",
        "Bring the laptop from Newton Block.",
        "Get the project files from Newton Block.",
        "Retrieve the textbook from Newton Block.",
        "Bring the extension cable from Newton Block.",
        "Pick up the data cable from Newton Block.",
        "Grab the backup hard drive from Newton Block.",
        "Fetch the instruction manual from Newton Block."
    };

    public static List<string> EdisonBlockTasks = new List<string>
    {
        "Get the wiring diagram from Edison Block.",
        "Fetch the toolbox from Edison Block.",
        "Pick up the multimeter from Edison Block.",
        "Retrieve the technical papers from Edison Block.",
        "Bring the circuit board from Edison Block.",
        "Grab the battery pack from Edison Block.",
        "Bring the soldering iron from Edison Block.",
        "Get the electrical schematic from Edison Block.",
        "Retrieve the electrical components from Edison Block.",
        "Fetch the safety manual from Edison Block."
    };

    public static List<string> FlemmingBlockTasks = new List<string>
    {
        "Get the presentation slides from Flemming Block.",
        "Fetch the marketing textbook from Flemming Block.",
        "Retrieve the financial analysis report from Flemming Block.",
        "Pick up the MBA student thesis papers from Flemming Block.",
        "Bring the latest research articles from Flemming Block.",
        "Get the project proposals from Flemming Block.",
        "Fetch the company brochure from Flemming Block.",
        "Retrieve the project summary from Flemming Block.",
        "Pick up the copy of the case study from Flemming Block.",
        "Bring the management book from Flemming Block."
    };

    public static List<string> StaffRoom2Tasks = new List<string>
    {
        "Fetch the spare office chair from Staff Room 2.",
        "Retrieve the coffee mug from Staff Room 2.",
        "Pick up the conference call speaker from Staff Room 2.",
        "Bring the printer cartridges from Staff Room 2.",
        "Get the stapler from Staff Room 2.",
        "Retrieve the office planner from Staff Room 2.",
        "Grab the note pad from Staff Room 2.",
        "Bring the extra keyboard from Staff Room 2.",
        "Pick up the highlighter from Staff Room 2.",
        "Fetch the calendar from Staff Room 2."
    };

    public static List<string> TuringBlockTasks = new List<string>
    {
        "Get the student project proposal from Turing Block.",
        "Retrieve the technical notebook from Turing Block.",
        "Pick up the coding manual from Turing Block.",
        "Fetch the university syllabus from Turing Block.",
        "Get the whiteboard markers from Turing Block.",
        "Bring the class notes from Turing Block.",
        "Retrieve the project design plan from Turing Block.",
        "Fetch the laptop from Turing Block.",
        "Grab the reference book from Turing Block.",
        "Bring the USB stick with lab files from Turing Block."
    };

    public static List<string> PantryTasks = new List<string>
    {
        "Get the tea cup from the Pantry.",
        "Fetch the coffee pot from the Pantry.",
        "Bring the sugar jar from the Pantry.",
        "Retrieve the water bottles from the Pantry.",
        "Get the snacks from the Pantry.",
        "Pick up the milk jug from the Pantry.",
        "Fetch the tea bags from the Pantry.",
        "Bring the coffee creamer from the Pantry.",
        "Retrieve the cutlery from the Pantry.",
        "Pick up the napkins from the Pantry."
    };

    public static List<string> Square1Tasks = new List<string>
    {
        "Get the order from Chai Nagri.",
        "Get the order from Paranta Corner.",
        "Get the order from Speedy Chow.",
        "Get the order from Domino's.",
        "Get the order from Venky's.",
        "Get the order from Keventer's.",
        "Get the order from South Point.",
        "Get the order from Punjab13.",
        "Get the order from Chaap Point.",
        "Get the order from LaPinos."
    };
    public static List<string> PicassoBlockTasks = new List<string>
{
    "Fetch the color palette from Picasso Block.",
    "Bring the design sketchbook from Picasso Block.",
    "Pick up the marker set from Picasso Block.",
    "Retrieve the poster printouts from Picasso Block.",
    "Get the art history textbook from Picasso Block.",
    "Bring the project portfolio from Picasso Block.",
    "Fetch the drawing tablet from Picasso Block.",
    "Grab the modeling clay from Picasso Block.",
    "Retrieve the concept board from Picasso Block.",
    "Pick up the stencil set from Picasso Block."
};

    public static List<string> Square2Tasks = new List<string>
    {
        "Get the food order from China Box.",
        "Get a photocopy from Tuck Shop 2.",
        "Get prints from Tuck Shop 2.",
        "Buy a pen from Tuck Shop 2.",
        "Buy a notebook from Tuck Shop 2.",
        "Get a stamp from Tuck Shop 2.",
        "Get a stapler from Tuck Shop 2.",
        "Get a file folder from Tuck Shop 2.",
        "Get a pair of scissors from Tuck Shop 2.",
        "Get a pack of paper from Tuck Shop 2."
    };

    // A method to get random tasks
    public static string GetRandomTask()
    {
        // You can expand this to choose from all task lists above
        var allTasks = new List<string>();
        allTasks.AddRange(DeansOfficeTasks);
        allTasks.AddRange(BabbageBlockTasks);
        allTasks.AddRange(StaffRoom1Tasks);
        allTasks.AddRange(NewtonBlockTasks);
        allTasks.AddRange(EdisonBlockTasks);
        allTasks.AddRange(FlemmingBlockTasks);
        allTasks.AddRange(StaffRoom2Tasks);
        allTasks.AddRange(TuringBlockTasks);
        allTasks.AddRange(PantryTasks);
        allTasks.AddRange(Square1Tasks);
        allTasks.AddRange(Square2Tasks);

        int randomIndex = UnityEngine.Random.Range(0, allTasks.Count);
        return allTasks[randomIndex];
    }
    public static List<string> GetRandomTaskBatch(int count, List<string> taskPool)
    {
        List<string> selectedTasks = new List<string>();
        List<string> copy = new List<string>(taskPool);

        for (int i = 0; i < count && copy.Count > 0; i++)
        {
            int index = UnityEngine.Random.Range(0, copy.Count);
            selectedTasks.Add(copy[index]);
            copy.RemoveAt(index);
        }

        return selectedTasks;
    }
}
