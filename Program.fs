open System

// Task 1
type Account = {accountNumber : string; mutable balance: float}
                member this.Print = 
                    Console.Write(this.accountNumber)
                    Console.Write(" ")
                    Console.Write(this.balance)

let starter = {accountNumber = "A1X"; balance = 100}

let Withdraw taken = 
    starter.balance <- starter.balance - taken

//let lowerBalance = Withdraw 10

let Deposit into =
    starter.balance <- starter.balance + into

//let higherBalance = Deposit 15

starter.Print

// Task 2

