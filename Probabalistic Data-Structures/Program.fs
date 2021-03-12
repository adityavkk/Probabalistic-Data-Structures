open System

module HashFunctions =
    let SDBMHash (v:string) (m: int) : int =
        let mutable h = 0
        for i = 0 to v.Length - 1  do
            h  <-  ((int)(v.Chars (i)))+(h <<< 6)+(h <<< 16)-h  
        abs h % m

    let SAXHash (v: string) (m: int): int =
        let mutable h = 0
        for i = 0 to v.Length - 1 do
            h <-  h ^^^ (h <<< 5) + (h >>> 2) + (int)(v.Chars (i)) 
        abs h % m


[<EntryPoint>]
let main argv =
    let x = HashFunctions.SDBMHash ("foo") 12
    let y = HashFunctions.SAXHash ("foobar") 12
    printfn "SDBM Hash %A" x
    printfn "SAX Hash %A" y
    0 // return an integer exit code