   M S B A M L   `   `   `  ����  ClienteConsultasMedicasN    HClienteConsultasMedicas.Views.ControlesRecepcionista.VerPacientesControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � $��20q�6   
�������  � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Pacientes Registrados��6   $��24(�61   $
��Bold"�6?   $��0,0,0,10q�6Q   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgPacientes��5      $��1��6(      AutoGenerateColumns$ False��65      
IsReadOnly$
 True��6Q      SelectionMode$ Single=�5      $
��0,10q�6*      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+6H     5      $ Nombre��6%   $ 2* 6P    65   �� *nombre+6P     5      $ Email��6%   $ 3* 6N    64   �� *email+6N     5      $ 	Teléfono��6%   $ 2* 6T    67   �� *
telefono+6T   5      �� 5   
   $��2��6   	 �� Orientation$	 
Horizontal=�6"   $
��Left=�6;   $��0,20,0,0q�6V   .+�5      �� $��0,0,10,0q�6   .+�5      �� $��Nombre��6   �� 5      -   5        
 ��Name$
 	txtNombre��5      $	��150��6-   5       �� 5"      $��0,0,10,0q�6   .+�5#      �� $��Email��6   �� 5$      -   5        $
 txtEmail��5$      $	��200��6,   5%      �� 5'      $��0,0,10,0q�6   .+�5(      �� $��	Teléfono��6   �� 5)      -   5        $
 txtTelefono��5)      $	��150��6/   5*      �� 5,      -   5        $��
Actualizar��5,      $	��100��6*   $
��10,0q�66   6D   �� 5-      -   5        $��Eliminar��5-      $	��100��6(   64   5.      5/      50      