   M S B A M L   `   `   `  ????D  @Notepaddy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	       Notepad.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	   -   5          ?Name$  
mainWindow??5   5    ? Title$ 
MainWindow??6	   $	??450??6   $	??801??6)    ? 
ResizeMode$ NoResize=?6I   .??5	      ? -   5         ?Name$
 grid??5	       ? ColumnDefinitions 5
   
   ?? 5      $	??675 ?6   ?? 5      $
??auto ?6    ? RowDefinitions 5   
   .+?5   
   ?? -   5         ??Name$ 	textBlock??5   "   $??0??6   67   ?? 5   
   -   5         ??Name$ minimizeNoteButton??5      $??18??6-   $??18??68   $??Right=?6D   $	??Top=?6`   $??0??6x   $
??26,4q?6?   $??-??6?   $??Cascadia Code SemiBold)?6?   6?   ?? 5   
   -   5        $ closeNoteButton??5      $??18??6*   $??18??65   $??Right=?6A   $	??Top=?6]   $??0??6u   $??4q?6?   $??X??6?   $??Cascadia Code SemiBold)?6?   6?   ?? 5   
   -   5        $ settingsButton??5      $	??115??6)   $??22??65   $??Bottom=?6A   $??1??6\   $??Settings??6l   6   ?? 5   
   -   5        $??noteList??5   G   $??1??6   $	??Top=?6"   $	??389??6:   ??5      ?? 5      .R?5      ?? ??6    ?? *Title+5      5      ?? 5   
   -   5        $ createNoteButton??5      $??18??6+   $??18??66   $??Bottom=?6B   $??Right=?6]   $??1??6y   $
??8,26q?6?   $??+??6?   $??Lucida Console)?6?   6?   5      5      