   M S B A M L   `   `   `  ????A  =Lab_12, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_12Lab_12  5   	       Lab_12.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Lab_12     5   	     ? Title$  Database viewer??5   	   $	??450??5	   	   $	??800??6   $	??300??5
   	   $	??400??6   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      $	??100 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid??5      $??0??6%   $??5q?65      AutoGenerateColumns$ False??6@      HorizontalGridLinesBrush
 ?????   RowBackground
 ?????   AlternatingRowBackground
 ?????$
??True??5      $
??Auto=?5      $
??Auto=?5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Компания??6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   ?? 
 ?? Path$
 Manufacturer?  5      $ Модель??6%   	 65   ?? $
 Model?  5      $ Код сборки??6%   	 69   ?? $

 Code?  5      $ Цена??6%   	 63   ?? $
 Price?  5      $) #Соотношение сторон??6%   	 6A   ?? $
 AspectRatio?  5      $ Разрешение??6%   	 69   ?? $
 
Resolution?  5      $ Диагональ??6%   	 68   ?? $
 Diagonal?  5      $) #Частота обновления??6%   	 6A   ?? $
 	FrameRate?  5      $ Матрица??6%   	 66   ?? $
 Matrix?5!      ?? 5#   
   $??1??6   $??Center=?6%   $??0, 20, 0, 20q?6B   .+?5$      ?? -   5        $??1??5$      $??0, 0, 0, 10q?6%   $??Добавить??6:   $??70??6M   6X   ?? 5%      -   5        $??1??5%      $??0, 0, 0, 10q?6%   $??Изменить??6:   $??70??6M   6X   ?? 5&      -   5        $??1??5&      $??0, 0, 0, 10q?6%   $??Удалить??6:   $??70??6L   6W   ?? 5'      -   5        $??1??5'      $??0, 20, 0, 10q?6%   $??
Выход??6;   $??60??6K   6V   5(      5)      5*      