   M S B A M L   `   `   `  ����L  HBlackDesertMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BlackDesertMarketBlackDesertMarket  5   	   #    BlackDesertMarket.MarketAlert   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:BlackDesertMarket     5   	     � Title$  MarketAlert��5   	   $	��663��6   $
��1001��6*    � 
ResizeMode$ NoResize=�67    � Icon$ /blackSpiritSimple.png��6M   ���	#FF646464.��5	      � .+�5
   
   �� 
���   �$��1q�6%   $��70,420,70,20q�69   ���	#FF3C3C3C._�5      �� -   5        $��ItemList��5      $��15,15,15,15q�6R   
���   �$ �� IsSynchronizedWithCurrentItem$ FalseY�6z   $
��Auto=�6�   $��False��6�   ���	#FFBBB1B1 �� View 5      �� 5      .P�5      �� $
��Name��6)    �� DisplayMemberBinding 67   ��  �� Path$
 Name��� 5      $��Level��6)    68   �� $ EnhancementLevel��� 5      $��Price��6)    68   �� $ PriceFormat��� 5      $��Available At��6)    6?   �� $ 	EndFormat�5      5      5      �� 5   
   -   5        $��RefreshButton��5      $��Refresh Queue��6&   
�������$��Center=�6Q   $	��Top=�6n   $��31��6�   $��92��6�   $��	0,166,0,0q�6�   ���	#FF211C1C6�   �� 5   
   
���   �$��1q�6%   $��45,15,600,300q�69   ._�5      � ���	#FF3C3C3C.+�5      �� -   5        $��DBListSearch��5      
�������$
��Left=�6A   $��	15,25,0,0q�6\    �� TextWrapping$
 Wrap=�6o   $��search item��6�   $	��Top=�6�   $	��120��6�   $��ExtraCondensed&�6�   ���	#FF1916166�   �� 5      -   5        $��AddFilterButton��5      
�������$��Add To Filter��6C   $��	0,95,20,0q�6[   $	��Top=�6n   $��Right=�6�   $��87��6�   $��31��6�   ���	#FF211C1C6�   �� 5       -   5        $��ShowMoreButton��5       
�������$��	Show More��6C   ���	#FF211C1C$��
0,0,20,134q�6�   $��Right=�6�   $��87��6�   $��31��6�   $��Bottom=�6�   �� 5!      -   5        $��
ItemDBList��5!      
���   �$��15,60,125,30q�6k   ���	#FFBBB1B1 5"      �� 5#      .P�5$      �� $
��Name��6.    6<   �� $
 Name�5%      5'      �� 5(      -   5        $��Enhancement��5(      $
��Left=�6.   $��
224,18,0,0q�6I   $	��Top=�6]   $	��120��6u   5)      5*      �� 5,   
   
���   �$��1q�6%   $��589,15,45,300q�69   ���	#FF3C3C3C._�5-      � .+�5.      �� -   5        $��FilterListSearch��5.      $
��Left=�62   $��
125,25,0,0q�6M   
�������$
 Wrap=�6t   $��Search filter��6�   $	��Top=�6�   $	��120��6�   ���	#FF1916166�   �� 5/      -	   5        $��DeleteFilter��5/      $��Delete From Filter��6-   $
��Left=�6J   $��	10,95,0,0q�6e   $	��Top=�6x   
�������$	��110��6�   $��31��6�   ���	#FF211C1C6�   �� 50      -
   5        $��
ItemFilter��50      $��125,60,15,30q�6X   
���   ����	#FFBBB1B1 51      �� 52      .P�53      �� $
��Name��6-    6;   �� $
 Name��� 54      $��Level��6-    6<   �� $ NameEnhancement�55      57      58      59      5<      5=      