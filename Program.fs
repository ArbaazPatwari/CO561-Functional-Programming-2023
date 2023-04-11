open System
open System.Threading

// Task 1
(* Created F# type called account with accountNumber and balance fields. It is a record since each case doesn't have to be specified for each function. Records also structure information instead of just data. Functions for withdraw and deposit, along with a print member have been defined. They regard the starter account an update the mutable value of balance.
*)
type Account = {accountNumber : string; mutable balance: float}
                member this.Print = 
                    Console.Write($"Account: {this.accountNumber}")
                    Console.Write(" | ")
                    Console.Write($"Balance: {this.balance}")

let starter = {accountNumber = "A1X"; balance = 100}

let Withdraw taken = 
    if starter.balance < taken then
        Console.Write("You cannot perform this transaction (balance too low)")
    else 
        starter.balance <- starter.balance - taken

//let lowerBalance = Withdraw 10

let Deposit into =
    starter.balance <- starter.balance + into

//let higherBalance = Deposit 15

starter.Print

// Task 2
(* Created a function named CheckAccount and it uses an account as an argument. It produces an output depending on the balance the account has. I made 6 accounts that test some arbitrary values within each band.

*)

Console.Write("\n")

let CheckAccount account =
    match account with
    |_ when account.balance > 100 -> Console.Write("balance is high")
    |_ when account.balance <= 100 && account.balance >= 10 -> Console.Write("balance is ok")
    |_ when account.balance <= 10 && account.balance >= 0 -> Console.Write("balance is low")
    |_ -> Console.Write("... (No account identified)")

let firstAccount = {accountNumber = "0001"; balance = 0.0}
let secondAccount = {accountNumber = "0002"; balance = 51.0}
let thirdAccount = {accountNumber = "0003"; balance = 5.0}
let fourthAccount = {accountNumber = "0004"; balance = 32.0}
let fifthAccount = {accountNumber = "0005"; balance = 105.0}
let sixthAccount = {accountNumber = "0006"; balance = 89.0}

Console.Write("The first account's ") 
CheckAccount firstAccount
Console.Write("\nThe second account's ")
CheckAccount secondAccount
Console.Write("\nThe third account's ")
CheckAccount thirdAccount
Console.Write("\nThe fourth account's ")
CheckAccount fourthAccount
Console.Write("\nThe fifth account's ")
CheckAccount fifthAccount
Console.Write("\nThe sixth account's ")
CheckAccount sixthAccount

// Task 3 
(* I made a list of the defined accounts in Task 2, and created two new lists that filter the balance of each account. Values are passed in to the list by specifying the original list in the List.filter() function, they are accepted or rejected if they meet the criteria e.g., balance is between 0 and below 50. Some print functions output the elements of the list though I couldn't seem to output just the account name, so each record is displayed to the console with account number and balance.
*)

let accounts = [firstAccount;secondAccount;thirdAccount;fourthAccount;fifthAccount;sixthAccount]

let sub50List = List.filter(fun x -> x.balance >= 0 && x.balance < 50) accounts
// Could not output account names individually, so this prints each record and their attributes
printfn $"\nThese accounts have less than 50 units:\n {sub50List}"

let above50List = List.filter(fun x -> x.balance >= 50) accounts

printfn $"These accounts have more than 50 units:\n {above50List}"

// Task 4
(* I specified this data to generate a list of 10 tickets, however had trouble completing the latter parts of the task. The DisplayTickets() function will print out each ticket that is present in a list (tickets list). This is done through by writing information to the console for a ticket, and iterating through each ticket to print out the information. I added a print member but this was not used. I tried to make BookSeat iterate through a list of tickets and update a record but I couldn't find a way to modify one record. I had to make a new record to implement the capturing of customer name and seat number, and updating that information instead. A simple if else statement lets the user repeat the function. I was also not sure how to implement threading and locking for the third part of the task.
*)

type Ticket = {mutable seat : int; mutable customer : string}
                member this.Display = 
                    Console.Write($"Seat: {this.seat}")
                    Console.Write(" | ")
                    Console.Write($"Customer: {this.customer}")
                    

let mutable tickets = [for n in 1..10 -> {Ticket.seat = n; Ticket.customer = ""}]

let TicketPrint x =
    Console.Write($"\nSeat Number: {x.seat} | ")
    Console.Write($"Customer name: {x.customer}")

let DisplayTickets x =
    List.iter TicketPrint tickets

DisplayTickets tickets
// Could not update a record from the tickets list so I made a new record to test the functionality on
let newTicket = {seat = 8; customer = "Marcus"}

let BookSeat seat =
    Console.Write($"\nPlease enter the name of the ticket holder: ")
    let c = Console.ReadLine()
    Console.Write($"Please enter the number of the ticket seat: ")
    let n = Int32.Parse(Console.ReadLine())
    newTicket.customer <- c
    //lock(c)(fun() -> newTicket.customer <- c) |> ignore
    newTicket.seat <- n
    //lock(n)(fun() -> newTicket.seat <- n) |> ignore
    Console.Write($"Ticket ready for: {newTicket.customer}")
    Console.Write(" | ")
    Console.Write($"Seated at: {newTicket.seat}")

BookSeat newTicket

Console.Write("\nWould you like to book another seat? Y/N")

let k = Console.ReadLine()
if k = "Y" || k = "y" then
    BookSeat newTicket
elif k = "N" || k = "n" then
    Console.WriteLine("Booking declined")
// Was not sure how to implement threading and locking for the BookSeat function
(*
let BookThread() =
    let thread = new Thread(BookSeat)
    thread.Start()

BookThread()
BookThread()
*)