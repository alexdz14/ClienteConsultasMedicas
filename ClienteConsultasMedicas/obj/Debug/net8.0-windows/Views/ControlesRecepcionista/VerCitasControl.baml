   M S B A M L   `   `   `  ����  ClienteConsultasMedicasJ    DClienteConsultasMedicas.Views.ControlesRecepcionista.VerCitasControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � $��20q�6   
�������  � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Citas Registradas��6   $��24(�6-   $
��Bold"�6;   $��0,0,0,10q�6M   �� 5   
    �� Orientation$ 
Horizontal=�6   $��	0,50,0,10q�6.   .+�5      �� -   5         ��Name$ 	txtBuscar��5      $	��250��5      $��30��5      $��0,0,10,0q�5      $��Center=�5       � ToolTip$- 'Buscar por paciente, motivo o estado...��5      �� 5      -   5        $��Limpiar��5      $��30��5      5      5       &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ dgCitas��5#      $��1��5$         AutoGenerateColumns$ False��5%         
IsReadOnly$
 True��5&         SelectionMode$ Single=�5'      $
��0,10q�5(         RowStyle 5,      �� 5-      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   
 �� Triggers
 5.      �� 5/       �� Binding 6&   �� *estado+ �� Value 	cancelada6A   .a�50      ��  �� Property � �� �� Value �	#FFFFD6D66;   �� 51       � ��
 �   �6;   �� 52       � ��$
 Bold"�6;   53      55         Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Paciente��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
paciente+6T     5:      $ Médico��6%   $ * 6P    65   �� *medico+6P     5;      $ Fecha y Hora��6%   $ * 6;    5<      �� 5=       �� Path$ 	fechaHora�6"    �� StringFormat$ dd/MM/yyyy HH:mm��63   5?        5@      $ Motivo��6%   $ 2* 6P    65   �� *motivo+6P     5A      $ Estado��6%   $ * 6P    65   �� *estado+6P   5C      �� 5F   
   -   5         ��Name$ btnCancelar��5F      $ ��Cancelar cita seleccionada��5G      $��2��5H      $	��220��5I      $��40��5J      $��0,20,0,0q�5K      $
��Left=�5L      5M      5N      5O      