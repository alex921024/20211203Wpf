   M S B A M L   `   `   `  ����F  B20241203Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_20241203Wpf_20241203Wpf  5   	   !    _20241203Wpf.DocumentViewer   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   &localclr-namespace:_20241203Wpf  5   	     � Title$  DocumentViewer��5	   	   $	��450��6    $	��800��6-    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.New��5      6;     5   
   -   5        $ ApplicationCommands.Open��5      6<     5   
   -   5        $ ApplicationCommands.Save��5      6<   .��5      ]� .+�5   
   `� $��40��6   $	��Top=�6"   $
��left=�6:   $	��Top=�6U    `� 
Background
 �����.�5      c� -   5         c�Name$ applicationToolBar��5      $��40��62   $	��180��6>   
�������.@�5      �� -   5         ��Name$ 	newButton��5      $��ApplicationCommands.New��6,   $��38��6N   $��38��6Z   .��5      �� $��32��6   $��32��6'   $��/new.png��63   5      �� 5      -   5        $ 
openButton��5      $��ApplicationCommands.Open��6-   $��38��6P   $��38��6\   .��5      �� $��32��6   $��32��6'   $��	/open.png��63   5      �� 5      -   5        $ 
saveButton��5      $��ApplicationCommands.Save��6-   $��38��6P   $��38��6\   .��5      �� $��32��6   $��32��6'   $��	/save.png��63   5      �� 5      -   5        $ trashButton��5      $��38��6.   $��38��6:   .��5      �� $��32��6   $��32��6'   $��
/trash.png��63   5      5      c� 5      -	   5        $ editingToolBar��5      $	��450��6.   .@�5       d� -
   5         d�Name$ 
boldButton��5       $ ��EditingCommands.ToggleBold��63   $��38��6Y   $��38��6e   .��5!      �� $��32��6   $��32��6'   $��	/bold.png��63   5"      d� 5#      -   5        $ italicButton��5#      $"��EditingCommands.ToggleItalic��65   $��38��6\   $��38��6h   .��5$      �� $��32��6   $��32��6'   $��/italic.png��63   5%      d� 5&      -   5        $ underlineButton��5&      $%��EditingCommands.ToggleUnderline��68   $��38��6b   $��38��6n   .��5'      �� $��32��6   $��32��6'   $��/underline.png��63   5(      #  Xceed.Wpf.Toolkit.ColorPicker  5)      -   5          Name$ fontColorPicker��5)   #   $	��100��6<   $��32��6H   $��Center=�6T      DisplayColorAndName$
 True��6o   6�   �� 5*      -   5        	 ��Name$	 fontFamilyComboBox��5*      $
��Left=�67   $��Center=�6R   $��32��6m   $	��100��6y   $��10,0,0,0q�6�   6�   �� 5+      -   5        $	 fontSizeComboBox��5+      $
��Left=�65   $��Center=�6P   $��32��6k   $��50��6w   $��10,0,0,0q�6�   6�   5,      5-      �� 5.   
   -   5        
 ��Name$
 	rtbEditor��5.      ���	#FFFAF9EF. �5/      /� 50      51      52      