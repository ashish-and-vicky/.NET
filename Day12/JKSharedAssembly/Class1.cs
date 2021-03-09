using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKSharedAssembly
{
    public class Class1
    {
        public string Hello()
        {
            return "Good afternoon";
        }
    }
}


/*
  
Why to generate a shared assembly?

==> Suppose a Teacher has shared a set of code to its student and the students take that code into their own systems. Now if suppose teacher further updates those set of codes. Now this will become a problem for students to use the old set of codes.
       Therefore we need to create such a system where if the parent is updated, then childs should not have any problem in using the updated one.
Steps to Make a shared assembly

- Generate the key pair
      sn -k file1.snk
 
- Sign the assembly with a "key pair"
     Assembly properties 

- Give the assembly "strong name"
      Build your assembly 

- Install the assembly into the GAC (Global Assembly Cache)
      gacutil /i Asm1.Dll


-----------------------------------------------------------
      gacutil /u <name-of-assembly> ---------------will uninstall it from Gac

before .net version 4 - c:\windows\assembly
version 4 onwards  - C:\Windows\Microsoft.NET\assembly\gac_msil ----check it by searching it in the start menu




To do the above steps:-
---------------------------
-Create a new project using VS---Open cmd prompt(Run as Administrator)---select a directory of where to generate the key value pair key(if different drive other than C drive then eg. E:-->Enter---then provide the path using cd)---type 'sn -k file1.snk' ---now goto/change directory in cli of where the assembly was made(if in same then do nothing)

-Create a new Project---Double click in its Properties---select Signing in left---Tick 'Sign the assembly'---In the drop down below 'Choose a strong name key pair'----Select <Browse> (we are not selecting <New> because it internally calls the above command for generating the key pair)---

-Select the .snk where it is saved (this completes our step 2)---Now Build the project from top bar, this automatically gives our assembly a strong name---

-Now as the assembly gets created in the bin folder therefore for 4th step type back in terminal 'cd bin\debug' (the .dll assembly is created in it)---type 'gacutil /i <name-of-our-assembly>.dll'

-Thus in the above way, we install the memory in the GAC (to uninstall it 'gacutil /u <name-of-assembly>.dll'

-Now Create a new project/assembly from VS---In Solution Explorer----Right click on 'References'---Add Reference---Browse---Select the assembly created above in <name-of-assembly>\bin\debug\<name-of-assembly>.dll---Add---OK---After Reference is added in SE---Right Click on it---select Properties(a menu will be opened)---make Copy Local as False---
-----this means VS by default creats a copies a copy of that assembly in itself by default and says that you to copy this assembly in the clients machine in GAC and it will work there also

-Hence in the above main code....we are taking and compiling the code which is taken from shared assembly----while creating a shared assembly----as we have created a copy of it----we can still change the content inside the method or class and run it successfully, but not the method itself.
*/