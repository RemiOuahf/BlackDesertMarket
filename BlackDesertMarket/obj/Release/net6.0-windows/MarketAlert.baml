   M S B A M L   `   `   `  ���� L  HBlackDesertMarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BlackDesertMarketBlackDesertMarket  #    BlackDesertMarket.MarketAlert   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:BlackDesertMarket       � Title$  MarketAlert��$	��663��$
��1001�� � 
ResizeMode$ NoResize=� � Icon$ /blackSpiritSimple.png�����	#FF646464.��� .+��� 
���   �$��1q�$��70,420,70,20q����	#FF3C3C3C._��� -   $��ItemList��$��15,15,15,15q�
���   �$ �� IsSynchronizedWithCurrentItem$ FalseY�$
��Auto=�$��False�����	#FFBBB1B1 �� View �� .P��� $
��Name�� �� DisplayMemberBinding ��  �� Path$
 Name��� $��Level�� �� $ EnhancementLevel��� $��Price�� �� $ PriceFormat��� $��Available At�� �� $ 	EndFormat��� -   $��RefreshButton��$��Refresh Queue��
�������$��Center=�$	��Top=�$��31��$��92��$��	0,166,0,0q����	#FF211C1C�� 
���   �$��1q�$��45,15,600,300q�._�� ���	#FF3C3C3C.+��� -   $��DBListSearch��
�������$
��Left=�$��	15,25,0,0q� �� TextWrapping$
 Wrap=�$��search item��$	��Top=�$	��120��$��ExtraCondensed&����	#FF191616�� -   $��AddFilterButton��
�������$��Add To Filter��$��	0,95,20,0q�$	��Top=�$��Right=�$��87��$��31�����	#FF211C1C�� -   $��ShowMoreButton��
�������$��	Show More�����	#FF211C1C$��
0,0,20,134q�$��Right=�$��87��$��31��$��Bottom=��� -   $��
ItemDBList��
���   �$��15,60,125,30q����	#FFBBB1B1 �� .P��� $
��Name�� �� $
 Name��� -   $��Enhancement��$
��Left=�$��
224,18,0,0q�$	��Top=�$	��120���� 
���   �$��1q�$��589,15,45,300q����	#FF3C3C3C._�� .+��� -   $��FilterListSearch��$
��Left=�$��
125,25,0,0q�
�������$
 Wrap=�$��Search filter��$	��Top=�$	��120�����	#FF191616�� -	   $��DeleteFilter��$��Delete From Filter��$
��Left=�$��	10,95,0,0q�$	��Top=�
�������$	��110��$��31�����	#FF211C1C�� -
   $��
ItemFilter��$��125,60,15,30q�
���   ����	#FFBBB1B1 �� .P��� $
��Name�� �� $
 Name��� $��Level�� �� $ NameEnhancement�