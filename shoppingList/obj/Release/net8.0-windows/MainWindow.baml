   M S B A M L   `   `   `  ���� G  CshoppingList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:shoppingListshoppingList      shoppingList.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:shoppingList     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     A =Wpf.Ui, Version=3.0.4.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml    � Title$  
MainWindow��$	��800��$	��500�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������ .��� -   .+��� 
����������	#FFF48D43$��1q�._�� .+��� $��	0,0,702,0q����	#FFF48D43$��0,0,1,0q����#757575  Wpf.Ui.Controls.Button  -   $��createButton��$	��102��$��35��$��
688,10,0,0q�$
��Left=�$	��Top=����	#FFF48D43$��0,0,0,0q�$��Utwórz��   CornerRadius$ 10,10,10,10��
�������  -   $��	AddButton��$	��102��$��35��$��
688,10,0,0q�$
��Left=�$	��Top=����	#FFF48D43$��0,0,0,0q�$��Dodaj��$ 10,10,10,10��
�������$y�Hidden=�  -   $��DeleteButton��$	��102��$��35��$��
578,10,0,0q�$
��Left=�$	��Top=����	#FFF48D43$��0,0,0,0q�$��Usuń��$ 10,10,10,10��
�������$y�Hidden=�  Wpf.Ui.Controls.ImageIcon  $��67��$��68��$��	10,28,0,0q�$
��Left=�$	��Top=�   Source$ /Resources/cart.png��  $��66��$��68��$��
16,356,0,0q�$
��Left=�$	��Top=�$" /Resources/configuration.png���� $	��245��$��69��$��
135,28,0,0q�$
��Left=�$	��Top=�$��Lista zakupów:��$��36(����	#FFF48D43�� -   $��ShoppingListBox��$��135,100,20,20q�$��16(����#333333$y�Visible=����� .R��� .+��� $
��Bold"����� *Name+�� $��Italic$����� *CreationTime+�� -   $��ProductListBox��$��135,100,20,20q�$��16(����#333333$y�Hidden=����� .R���  �� Orientation$ 
Horizontal=�.+��� -    d� 	IsChecked �� *Status+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��5,0,0,0q����� *ProductName+  -   $��
BackButton��$	��102��$��35��$��
688,50,0,0q�$
��Left=�$	��Top=����	#FFF48D43$��0,0,0,0q�$��Cofnij��$ 10,10,10,10��
�������$y�Hidden=�