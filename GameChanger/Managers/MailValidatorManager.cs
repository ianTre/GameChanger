namespace GameChanger.Managers
{
    public class MailValidatorManager
    {
        
            public string mailIngresado;     // var q  guarda el string ingresado
            public bool esMail;   // var que devuelve el booleano final


            public MailValidatorManager()//PEPE
            {
                //ACA SE CREA AUTOMATICAMENTE EL OBJETO

            }

            public bool ComprobDeMail(string textoInput)
            {
                 if (string.IsNullOrEmpty(textoInput)) 
                 {                   
                   return false;

                 }
                
                mailIngresado = textoInput.Trim(); // Limpiando el texto y guardarlo en MailIngresado

                mailIngresado = mailIngresado.ToUpper();

                char[] mailarray = mailIngresado.ToCharArray(); // crea un array de char

                int largoarray = mailIngresado.Length; // pareciera  que no haría falta

                int index = 0;
                int cantarrobas = 0;
                int posarroba = 0;
                int cuentapuntos = 0;
                int cuentaespacios = 0;
                int cuentacharesp = 0;

                foreach (char i in mailarray)
                {

                    if (i == '¡' || i == '!' || i == '"' || i == '#' || i == '$' || i == '%' || i == '(' || i == 'ç')

                    {
                        cuentacharesp++;
                    }

                    if (i == ')' || i == ',' || i == ';' || i == '>' || i == '<' || i == '°' || i == '¬')
                    {
                        cuentacharesp++;
                    }
                    if (i == '[' || i == ']' || i == '|' || i == '~' || i == ':' || i == 'ñ')

                    {
                        cuentacharesp++;
                    }
                    if (i == 'Á' || i == 'É' || i == 'Í' || i == 'Ó' || i == 'Ú')
                    {
                        cuentacharesp++;
                    }
                    if (i == 'Ä' || i == 'Ë' || i == 'Ï' || i == 'Ö' || i == 'Ü')
                    {
                        cuentacharesp++;
                    }


                    if (i == '@')

                    {
                        cantarrobas++;
                        posarroba = index;
                    }

                    if (i == '.' && cantarrobas == 1) // funciona 
                    {
                        cuentapuntos++; // guarda la cant de puntos desp del @

                    }
                    if (i == ' ')
                    { cuentaespacios++; }

                    index++;
                }

                if (cantarrobas > 1 || cantarrobas == 0 || index <= 5 || posarroba < 3 || posarroba >= largoarray - 5 || cuentapuntos > 2 || cuentapuntos < 1 || cuentaespacios > 0 || cuentacharesp > 0 || mailarray[posarroba + 1] == '.')

                {
                    esMail = false;

                }

                else
                {
                    int posmenos3 = largoarray - 3; // .ar
                    int posmenos4 = largoarray - 4; // .com
                    int posmenos7 = largoarray - 7; // .com.ar 

                    if (mailarray[posmenos7] == '.' && mailarray[posmenos3] == '.' && cuentapuntos == 2)
                    {
                        esMail = true;
                    }
                    else
                    {
                        if (cuentapuntos == 1)
                        {

                            if (mailarray[posmenos3] == '.' || mailarray[posmenos4] == '.')
                            {
                                esMail = true;
                            }

                        }

                        else { esMail = false; }
                    }
                }
                return esMail;

            }
        
    }
  

}
