
#include <windows.h>
#include <stdio.h>

long long total, checked;
int hardways[8]; // count of total hardways won...

int card[5][5];
int nums[5];

int card_count;
int current_card;
int allcards[90000][5][5];

// 0-3 horizontal (top,down)
// 5-7 vertical (b,i,g,o)

#define BALL_B 0x001
#define BALL_I 0x002
#define BALL_N 0x004
#define BALL_G 0x008
#define BALL_O 0x010

void printcard( int card[5][5] )
{
	int a;
	for( a = 1; a < 5; a++ )
	fprintf( stderr, "%d %d %d %d %d\n"
			, card[a-1][0]
			, card[a-1][1]
			, card[a-1][2]
			, card[a-1][3]
			, card[a-1][4] );
}

int can_bingo( void )
{
	int n;
	int bingo_col, bingo_row;
	int result;
	bingo_col = BALL_B|BALL_I|BALL_G|BALL_O; // all balls or'd
	bingo_row = 0x1f; 

	for( n = 0; n < 5; n++ )
	{
		if( nums[n] > 15 )
		 	bingo_col &= ~BALL_B;
		else
		 	bingo_row &= ~BALL_B;

		if( nums[n] <= 15 || nums[n] > 30 )
			bingo_col &= ~BALL_I;
		else
		 	bingo_row &= ~BALL_I;

		if( nums[n] <= 30 || nums[n] > 45 )
			bingo_col &= ~BALL_N;
		else
			bingo_row &= ~BALL_N;

		if( nums[n] <= 45 || nums[n] > 60 )
			bingo_col &= ~BALL_G;
		else
			bingo_row &= ~BALL_G;

		if( nums[n] <= 60 )
			bingo_col &= ~BALL_O;
		else
			bingo_row &= ~BALL_O;

	}
	if( !bingo_row )
		return TRUE;
	if( bingo_col )
		return TRUE;
	return FALSE;
}


void check_hardway( int card[5][5] )
{
	int n, i, row, col;
	for( n = 0; n < 8; n++ )
	{
		switch( n )
		{
		case 2:
		case 3:
         row = n+1;
			if(0)
			{
		case 0:
		case 1:
            row = n;
			}
			for( i = 0; i < 5; i++ )
				if( card[row][0] == nums[i] )
               break;
			if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[row][1] == nums[i] )
					break; }
         else break;
			if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[row][2] == nums[i] )
					break; }
         else break;
			if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[row][3] == nums[i] )
					break; }
         else break;
			if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[row][4] == nums[i] )
					break; }
         else break;
			if( i < 5 )
			{
            hardways[n]++;
            printf( "%lld %lld %d %d %d %d %d %d %d\n", total, checked, current_card, n, nums[0], nums[1], nums[2], nums[3], nums[4] );
            //printcard( card );
            //return;
         }
         break;
		case 4:
		case 5:
         col = n - 4;
			if(0) {
		case 6:
		case 7:
            col = n - 3;
			}
			for( i = 0; i < 5; i++ )
				if( card[0][col] == nums[i] )
               break;
			if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[1][col] == nums[i] )
					break; }
         else break;
         if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[2][col] == nums[i] )
               break; }
         else break;
         if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[3][col] == nums[i] )
               break; }
         else break;
         if( i < 5 ) { for( i = 0; i < 5; i++ )
				if( card[4][col] == nums[i] )
					break; }
         else break;
			if( i < 5 )
			{
            hardways[n]++;
            printf( "%lld %lld %d %d %d %d %d %d %d\n", total, checked, current_card, n, nums[0], nums[1], nums[2], nums[3], nums[4] );
            //printcard( card );
            //return;
         }
         break;
		}
	}
}

int load_cards( void )
{
	FILE *in = fopen( "f126-2.dat", "rb" );
	if( in )
	{
		int c, d, n;
		char data[12];
		long int card; // = starting - 1 /*((( long)rand() << 12 ) + rand()) % 87984 */;
		for( card_count = 0; fread( data, 1, 12, in ); card_count++ )
		{
			for( c = 0; c < 6; c++ )
			{
				n = 0;
				for( d = 0; d < 25; d++ )
				{
					if( d != 12 )
					{
						allcards[card_count][d%5][d/5] = ((data[n/2] >> 
														( (!( n & 1 )) * 4) )&0xF) 
														+ ( (d / 5)*15)+1;
						n++;
					}
				}
			}
		}
	}
}


int main( int argc, char **argv )
{
   int _a = 0;
   unsigned long tick = GetTickCount();
	int startat = 1, stopat;
#define a nums[0]
#define b nums[1]
#define c nums[2]
#define d nums[3]
#define e nums[4]
	load_cards();
	fprintf( stderr, "Loaded %d cards\n", card_count );
	for( a = 1; a <= 5; a++ )
	{
		card[a-1][0] = a;
		card[a-1][1] = a + 15;
		card[a-1][2] = a + 30;
		card[a-1][3] = a + 45;
		card[a-1][4] = a + 60;

		fprintf( stderr, "%d %d %d %d %d\n"
				, card[a-1][0]
				, card[a-1][1]
				, card[a-1][2]
				, card[a-1][3]
				, card[a-1][4] );
	}
	if( argc < 2 || !argv[1] )
		startat = 1;
	else
		startat = 		atoi(argv[1]);
	
	if( argc < 3 || !argv[2] )
		stopat = 1;
	else
		stopat = 		atoi(argv[2]);

	for( a = startat; a <= stopat; a++ )
	{
		for( b = a+1; b <= 75; b++ )
		{
			for( c = b+1; c <= 75; c++ )
			{
				for( d = c+1; d <= 75; d++ )
				{
					for( e = d+1; e <= 75; e++ )
					{
						total++;
						if( can_bingo() )
						{
							checked++;
							for( current_card = 0; 
									current_card < card_count; 
									current_card++ )
								check_hardway( allcards[current_card] );
						}	
						if( a != _a )
						{
							_a = a;
							fprintf( stderr, "Total Samples: (%d) %lld %d %d %d %d %d %d %d %d %d %d %d %d %d\r"
                           , GetTickCount() - tick
									, total
									, hardways[0]
									, hardways[1]
									, hardways[2]
									, hardways[3]
									, hardways[4]
									, hardways[5]
									, hardways[6]
									, hardways[7]
                            , a, b, c, d, e
									);
                     fflush( stdout );
						}
					}
				}
			}
		}
	}
	
	for( a = 0; a < 8; a++ )
	{
		if( hardways[a] )
		fprintf( stderr, "\n%d:%lld %lld (%Ld)", hardways[a], total, checked, total / hardways[a] );
	}
   return 0;
}


