using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;
namespace Juego{
class Animaciones{

  public static void animar()
    {
        string[] steps = GetFrames(); //Llamada a la funcion que tiene los ascii art de la animacion
        Console.Clear(); //Limpiamos la pantalla
        DateTime startTime = DateTime.Now; //Guarda el tiempo de inicion
        TimeSpan duracionAnimacion = TimeSpan.FromSeconds(5); //Guardamos en duracionAnimacion un periodo de tiempo de 5 segundos
        int i = 0;
        //Este bucle continua hasta que se apriete Esc
        do {
            while (! Console.KeyAvailable) { //Mientras no se aprite ninguna tecla
                Console.SetCursorPosition(0,0); //Hace que se empiece a escribir en la posicion (0, 0)
                string step = steps[i++ % 10];
                Console.Write(step);
                Thread.Sleep(200);
                if (DateTime.Now - startTime >= duracionAnimacion)
                    break;
            }    
            if (DateTime.Now - startTime >= duracionAnimacion)
                break;   
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        Console.WriteLine();
    }
    private static string[] GetFrames()
    {
        return new string[10] {
@"""
                                               +***                   
                                              --=+*+                  
                                             -===--                   
                                             -=---                    
                                            -===--                    
                                            --==-                     
                                           -===-                      
                                          -==-:                       
                                          -==--                       
                                          ----                        
                                        =--==-                        
                                      -==---=-                        
                     -=============================                   
                ======--------------==========----===:                
              ===------------------=-=========------==                
             -==-------:...:::::::-:=:-=-==--=-::--==+                
             -*+==:::::::::::::::::::::-:=:-:-:::-=+++                
             .:+*+++===----:::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              -***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-::::::::-***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
""",
@"""
                                          +***                        
                                         :-=++-                       
                                         --==-                        
                                         -=---                        
                                        -===-                         
                                       ---=--                         
                                       :-==-                          
                                       --=:-                          
                                       :-=-                           
                                      :----                           
                                      --=--                           
                                    -=---=-                           
                     -=============================                   
                ======------------===-======------===:                
              ===-----------------======-===--------==                
             -==----::.::::::::.:--:---==--=:::::--==+                
             -*+==:::::::::::::::::..::-:::-:::::-=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-::::::::-***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 ::::::::::::::::::::::::::::::::::                   
                   .:::::::::::::::::::::::::::-:                     
                       =+****-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                                      +++                             
                                     =***+                            
                                     --=-:                            
                                    :=--=-                            
                                    :==--                             
                                    -=--:                             
                                   --==--                             
                                   -===-                              
                                   -=-=-                              
                                   -==-                               
                                   -=--                               
                                  ----=-                              
                                 -=------                             
                     ==============================                   
                ======----------=========---------===:                
              ===--------------==--=====-=----------==                
             -==------::...:::-:---=:=--:-::::----:==+                
             -*+=-:::::::::::::::---:-:-:-:::::::-=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+****-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                                 =++                                  
                                =***=                                 
                                --=--                                 
                                -=-=-                                 
                                -===-                                 
                                -==-:                                 
                                --=-.                                 
                                -==-                                  
                                -=--                                  
                                --=-                                  
                                ----                                  
                                ------                                
                               -=---=--                               
                     ==============================                   
                ======--------==========----------===:                
              ===-------------==========------------==                
             -==------------:-::----=----::::------==+                
             -*+==:...:::::::-::::::-:::::::::::--=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                            =+=                                       
                           +***=                                      
                           -:=--                                      
                           --=--.                                     
                           :-===-                                     
                            -==-:                                     
                            ---=-                                     
                            :-==-                                     
                             -----                                    
                             :-=--                                    
                              --:-                                    
                              =-----                                  
                             -=---=--                                 
                     -=============================                   
                ======-------==========-----------===:                
              ===-----------=-======-==-------------==                
             -==--:::----::.-::--=-=:-:-....:::::::==+                
             -*+=-:::::::::::::...:-:..:::..::::--=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                       +**=                                           
                      -++=-:                                          
                       -===-                                          
                       -=---                                          
                       :-==-:                                         
                        ---=-                                         
                        -===-                                         
                         -==--                                        
                         :--=-:                                       
                          :-=--                                       
                           -==---                                     
                           --:-----                                   
                     -=============================                   
                ======-----==-=======-------------===:                
              ===----------=======-=-=--------------==                
             -==------:::::----=:=-:---::::::..::::==+                
             -*+=-:::::::::::::::::::...:::::::::-=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              -***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-+**=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                            =+=                                       
                           +***=                                      
                           -:=--                                      
                           --=--.                                     
                           :-===-                                     
                            -==-:                                     
                            ---=-                                     
                            :-==-                                     
                             -----                                    
                             :-=--                                    
                              --:-                                    
                              =-----                                  
                             -=---=--                                 
                     -=============================                   
                ======-------==========-----------===:                
              ===-----------=-======-==-------------==                
             -==--:::----::.-::--=-=:-:-....:::::::==+                
             -*+=-:::::::::::::...:-:..:::..::::--=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                                 =++                                  
                                =***=                                 
                                --=--                                 
                                -=-=-                                 
                                -===-                                 
                                -==-:                                 
                                --=-.                                 
                                -==-                                  
                                -=--                                  
                                --=-                                  
                                ----                                  
                                ------                                
                               -=---=--                               
                     ==============================                   
                ======--------==========----------===:                
              ===-------------==========------------==                
             -==------------:-::----=----::::------==+                
             -*+==:...:::::::-::::::-:::::::::::--=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+***+-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                                      +++                             
                                     =***+                            
                                     --=-:                            
                                    :=--=-                            
                                    :==--                             
                                    -=--:                             
                                   --==--                             
                                   -===-                              
                                   -=-=-                              
                                   -==-                               
                                   -=--                               
                                  ----=-                              
                                 -=------                             
                     ==============================                   
                ======----------=========---------===:                
              ===--------------==--=====-=----------==                
             -==------::...:::-:---=:=--:-::::----:==+                
             -*+=-:::::::::::::::---:-:-:-:::::::-=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-:::::::::***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 :::::::::::::::::::::::::::::::::.                   
                   .:::::::::::::::::::::::::::-:                     
                       =+****-=:-=-=-===***++-                        
                           ================                           
"""
,
@"""
                                          +***                        
                                         :-=++-                       
                                         --==-                        
                                         -=---                        
                                        -===-                         
                                       ---=--                         
                                       :-==-                          
                                       --=:-                          
                                       :-=-                           
                                      :----                           
                                      --=--                           
                                    -=---=-                           
                     -=============================                   
                ======------------===-======------===:                
              ===-----------------======-===--------==                
             -==----::.::::::::.:--:---==--=:::::--==+                
             -*+==:::::::::::::::::..::-:::-:::::-=+++                
             .:+*+++===---::::::::::::::---====+++++-:                
              :::-==****+++++++++++++++++++***+*+:::::                
              :::::::::-:---++-=+-++-=+--=-:::::::+++=                
              :***=:::::::::::::::::::::::::::::::+**=                
              :***-:-:=**+:::::::-::::::::-***+:+::+-                 
               :=:::::=**+::--::-***=:-+:::=*+-::::::                 
                :::::::++::::::::+*+::::::::-:::::::                  
                 ::::::::::::::::::::::::::::::::::                   
                   .:::::::::::::::::::::::::::-:                     
                       =+****-=:-=-=-===***++-                        
                           ================                           
"""                              
        };
    }
}
}
