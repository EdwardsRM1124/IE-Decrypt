/*The MIT License (MIT)

Copyright (c) 2012 Jordan Wright <jordan-wright.github.io>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace PasswordVaultTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a handle to the Widnows Password vault
            Windows.Security.Credentials.PasswordVault vault = new PasswordVault();
            // Retrieve all the credentials from the vault
            IReadOnlyList<PasswordCredential> credentials = vault.RetrieveAll();
            // The list returned is an IReadOnlyList, so there is no enumerator.
            // No problem, we'll just see how many credentials there are and do it the
            // old fashioned way
            for (int i = 0; i < credentials.Count; i++)
            {
                // Obtain the credential
                PasswordCredential cred = credentials.ElementAt(i);
                // "Fill in the password" (I wish I knew more about what this was doing)
                cred.RetrievePassword();
                // Print the result
                Console.WriteLine(cred.Resource + ':' + cred.UserName + ':' + cred.Password);
            }
            Console.ReadKey();
        }
    }
}
