   M S B A M L   `   `   `  ????@  <Lab_9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_9Lab_9  5   	       Lab_9.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_9     5   	     ? Title$  
MainWindow??5   	   $	??300??5	   	   $	??500??6   $	??200??5
   	   $	??300??6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??20 ?6   6*   ?? 5      6   .+?5   
   o? $??Center=?6   $??2??6*   .@?5      m? $
??File??6   .@?5      m? -   5        $??	File_Open??5   .   $??	Open file??6   6R   m? 5      -   5        $??	File_Save??5   .   $??	Save file??6   6T   ?? 5      m? 5      -   5        $??
File_Close??5   *   $??Close??6   6S   5      m? 5      $
??Edit??6   .@?5      m? -   5        $??
Edit_Clear??5   *   $??Clear??6   6S   5      5      ?? 5   
   -   5         ??Name$ 	inputText??5      $??0??6%   $??1??65   $??5q?6B    ?? TextWrapping$
 Wrap=?6M   $??16(?6a    ?? AcceptsReturn$
 True??5      " ?? VerticalScrollBarVisibility$
 Auto=?6'   .??6J    ? ContextMenu 5      ?? 5       .@?5!      m? -   5        $??In_Context_Copy??5!   -   $
??Copy??6   6b   m? 5"      -   5        $??In_Context_Paste??5"   .   $??Paste??6   6]   m? 5#      -   5        $??In_Context_Cut??5#   ,   $	??Cut??6   6_   m? 5$      -	   5        $??In_Context_Delete??5$   /   $??Delete??6   6e   5%      .??5&   #   5'      5(      5)      