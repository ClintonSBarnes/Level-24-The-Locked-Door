{//instantiates the locking door and sets passcode.
    Console.Write("Enter your initial passcode: ");
    LockingDoor myDoor = new LockingDoor(Convert.ToInt16(Console.ReadLine()));
    //runs the program's loop.
    myDoor.DoorAndLockState();
}

class LockingDoor
{
    private int _passcode;
    private Lock _lock;
    private Door _door;
    private string quit = "no";

    //simple menu that allows the user to choose the next action or to quit the program.
    public void DoorAndLockState()
    {
        while (quit != "Y")
        {
            string action;

            Console.WriteLine($"The door is currently {_door} and it is {_lock}.\n" +
                $"You can 'open', 'close', 'lock' or 'unlock' the door. " +
                $"Or you can 'reset' your passcode. What action would you like to take?");
            action = Console.ReadLine();
            if (action == "open" || action == "close" || action == "lock" || action == "unlock")
            {
                DoorLockChange(action);
            }
            else if (action == "reset")
            {
                SetNewPasscode();
            }
            //allows for quitting the loop and program.
            Console.WriteLine("Would you like to quit the program?");
            quit = Console.ReadLine();

        }
    }
    //class cosntructor
    public LockingDoor(int passcode)
    {
        _lock = Lock.locked;
        _door = Door.closed;
        _passcode = passcode;

    }

    //allows for password reset
    public void SetNewPasscode()
    {
        int oldPasscode;
        int newPasscode;
        Console.Write("Please enter your current passcode: ");
        oldPasscode = Convert.ToInt16(Console.ReadLine());

        if (oldPasscode == _passcode)
        {
            Console.Write("Enter your new passcode: ");
            newPasscode = Convert.ToInt16(Console.ReadLine());

            _passcode = newPasscode;


        }
        else
        {
            Console.WriteLine("That is not a valid code.");
        }
    }

    //processes the logic for actions and conducts the state change actions upon verification.
    public void DoorLockChange(string action)
    {
        int passcode = -1;
        if (action == "open" && _door == Door.closed && _lock == Lock.locked)
        {
            string escape = "text";
            while (passcode != _passcode || escape != "Q")
            {

                Console.Write("Please enter your passcode: ");
                passcode = Convert.ToInt16(Console.ReadLine());
                if (passcode == _passcode)
                {
                    _door = Door.open;
                    _lock = Lock.unlocked;
                    Console.WriteLine("The door has been unlocked and opened.");
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered the WRONG passcode");
                    Console.Write("(Q)uit attempting the passcode?");
                    escape = Console.ReadLine();
                    if (escape == "Q")
                    {
                        break;
                    }
                }
            }
        }
        else if (action == "open" && _door == Door.open)
        {
            Console.WriteLine("The door is already open.");
        }
        else if (action == "open" && _door == Door.closed && _lock == Lock.unlocked)
        {
            Console.WriteLine("The door has been opened.");
        }
        else if (action == "close")
        {
            _door = Door.closed;
            Console.WriteLine("The door has been closed.");
        }
        else if (action == "lock")
        {
            _lock = Lock.locked;

            _door = Door.closed;
            Console.WriteLine("The door has been locked.");
        }
    }

}
//enumerations of states.
enum Door { open, closed }
enum Lock { locked, unlocked }