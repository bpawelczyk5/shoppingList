   M S B A M L   `   `   `  ����G  CshoppingList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:shoppingListshoppingList  5          shoppingList.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:shoppingList     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5        � Title$  
MainWindow��5	      $	��800��5
      $	��500��5       � WindowStyle$
 None=�5       � AllowsTransparency$
 True��5      
������ .��5      � -   5        .+�5   
   �� 
�������$��1q�5       �� CornerRadius$ 25��5      ._�5      � .+�5        Wpf.Ui.Controls.Button  -   5        $��X��5      $��13(�6(   
������ $��Right=�6P   $	��Top=�6l   
������  J� RenderTransformOrigin$ 0.318,0.691&�6�   $��0,8,10,0q�6�   $��19��6�     5      -   5        $��createButton��5%      $	��102��5      $��36��5      $��
688,44,0,0q�5      $
��Left=�5      $	��Top=�5      ���	#FFF48D43$��0,0,0,0q�5!      $��Utwórz��5"         CornerRadius$ 10,10,10,10��5#      
�������5%        5'      -   5        $��	AddButton��52   )   $	��102��5(      $��35��5)      $��
688,10,0,0q�5*      $
��Left=�5+      $	��Top=�5,      ���	#FFF48D43$��0,0,0,0q�5.      $��Dodaj��5/      $ 10,10,10,10��50      
�������$y�Hidden=�52      6)     53      -   5        $��DeleteButton��5>   )   $	��102��54      $��35��55      $��
578,10,0,0q�56      $
��Left=�57      $	��Top=�58      ���	#FFF48D43$��0,0,0,0q�5:      $��Usuń��5;      $ 10,10,10,10��5<      
�������$y�Hidden=�5>      6)     Wpf.Ui.Controls.ImageIcon  5?      $��67��5@      $��68��5A      $��	35,20,0,0q�5B      $
��Left=�5C      $	��Top=�5D         Source$ /Resources/cart.png��5E        5F      $��66��5G      $��68��5H      $��
30,390,0,0q�5I      $
��Left=�5J      $	��Top=�5K      $" /Resources/configuration.png��5L      �� 5M      $	��245��5N      $��69��5O      $��
135,28,0,0q�5P      $
��Left=�5Q      $	��Top=�5R      $��Lista zakupów:��5S      $��36(�6.   ���	#FFF48D436<   �� 5U      -   5        $��ShoppingListBox��5V      
������ $��135,100,20,20q�5X      $��16(�5Y      ���#333333$y�Visible=�5[      ��5]      �� 5^      .R�5_      �� .+�5`   "   �� $
��Bold"�6B   ��6,   �� *Name+6B   �� 5a   "   $��Italic$�6J   ��6,   �� *CreationTime+6J   5b      5c      5e      �� 5g      -   5        $��ProductListBox��5h      
������ $��135,100,20,20q�5j      $��16(�5k      ���#333333$y�Hidden=�5m      ��5n      �� 5o      .R�5p      ��  �� Orientation$ 
Horizontal=�6)   .+�5q   "   �� -   5         d� 	IsChecked 5q   +   �� *Status+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5s   %   �� 5t   "   $��5,0,0,0q�6I   ��6,   �� *ProductName+6I   5u      5v      5x        5z      -	   5        $��
BackButton��5�   )   $	��102��5{      $��35��5|      $��
688,50,0,0q�5}      $
��Left=�5~      $	��Top=�5      ���	#FFF48D43$��0,0,0,0q�5�      $��Cofnij��5�      $ 10,10,10,10��5�      
�������$y�Hidden=�5�      6)   5�      5�      5�      5�      