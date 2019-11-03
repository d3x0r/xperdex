//#define USE_RANDOM_0 // rand() * range / MAX
//#define USE_RANDOM_1 // sort rand key nums
#define USE_RANDOM_2 // rand() % range
//#define USE_RANDOM_3 // (rand() >> 4 ) % range


#include <stdio.h>
#include <stdlib.h>
#include <types.h>
#include <configscript.h>

#define FALSE 0
#define TRUE (!FALSE)

FILE *calls;
FILE *pays;
FILE *pots;
FILE *ballstats;
int quiet;
long long total, checked, cards_played;
void (*DrawRandomNumbers)(void);

// sessions * games * halls * players * faces
// 8 * 6 * 15 * 480 = 345600
// at 0.007 cents is $2419.2



// jackpots are in units of .01 * 8 pennies
//     800ths of a penny
//  partial pennies  jackpot % ( 800 )
//  pennies = jackpot / 800 % 100;
//  dollars = jackpot / 80000;

long long minimum_jackpot = 11990000;
long long jackpots[8]; // accumulated per day based on cards played
long long total_payout;
int jackpots_paid;
long long highest_jackpot;
int highest_day;
int hardways[8]; // count of total hardways won...
int last_won_in[8]; // number of balls the last winner won in...

int card[5][5];
int balls = 5; // number of balls called
int nums_called[75];
int nums[75];

int card_count;
int current_card;

int accrual = 10000;
int days = 365; // 10 years.
int offset = 0;
int skip = 50; // when offset == skip - offset = 0
int halls = 8; // number of halls to sell to... a different set of numbers needs to be drawn
int players = 240; // 80 * 6 so each player can buy 1 1 on
int games = 6; // 6 games ( offset per player )
//int faces = 6;
int sessions = 8; // 8 sessions per day;

char cardfile[256];
int allcards[90000][5][5];

int day, session, game, hall, player
													//, face
;


// 0-3 horizontal (top,down)
// 5-7 vertical (b,i,g,o)

typedef struct {
	_32 B:3;
	_32 I:3;
	_32 N:3;
	_32 G:3;
	_32 O:3;
} valid_bingo_row;

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

void DrawRandomNumbers0( void )
{
	int n;
   int max = 75;
	int r;
	static int original[75];
	static int work_nums[75];
	if( original[1] != 1 )
	{
		for( n = 1; n <= 75; n++ )
		{
         original[n-1] = n;
		}
	}
   memcpy( work_nums, original, sizeof( original ) );
	for( n = 0; n < balls; n++ )
	{
		r = rand() * max / RAND_MAX;
		if( r > max || r < 0 )
         printf( "Bad ball pick!!!!\n" );
		nums_called[work_nums[r]-1]++;
		nums[n] = work_nums[r];
      work_nums[r] = work_nums[--max];
	}
	if( calls )
	{
		fprintf( calls, "%d %d %d %d"
				 , day
				 , session
				 , game
				 , hall );
		for( n = 0; n < balls; n++ )
			fprintf( calls, " %d", nums[n] );
		fprintf( calls, "\n" );
	}
}

void DrawRandomNumbers1( void )
{
	int n;
   int max = 75;
	int r;
	static int original[75];
	static int work_nums[75];
	if( original[1] != 1 )
	{
		for( n = 1; n <= 75; n++ )
		{
         original[n-1] = n;
		}
	}
   memcpy( work_nums, original, sizeof( original ) );
	for( n = 0; n < balls; n++ )
	{
		r = rand() % max;
		if( r > max || r < 0 )
         printf( "Bad ball pick!!!!\n" );
		nums_called[work_nums[r]-1]++;
		nums[n] = work_nums[r];
      work_nums[r] = work_nums[--max];
	}
	if( calls )
	{
		fprintf( calls, "%d %d %d %d"
				 , day
				 , session
				 , game
				 , hall );
		for( n = 0; n < balls; n++ )
			fprintf( calls, " %d", nums[n] );
		fprintf( calls, "\n" );
	}
}

typedef struct holder_tag
{
   int number;
   int r;
   struct holder_tag *pLess, *pMore;
} HOLDER, *PHOLDER;

int nHolders;
HOLDER holders[75];

PHOLDER sort( PHOLDER tree, int number, int r )
{
   if( !tree )
   {
      tree = holders + (nHolders++);
      tree->number = number;
      tree->r = r;
      tree->pLess = tree->pMore = NULL;
   }
   else
   {
      if( r > tree->r )
         tree->pMore = sort( tree->pMore, number, r );
      else
         tree->pLess = sort( tree->pLess, number, r );
   }
   return tree;
}

int nNumber;
void FoldTree( int *numbers, PHOLDER tree )
{
   if( tree->pLess )
      FoldTree( numbers, tree->pLess );
   numbers[nNumber++] = tree->number;
   if( tree->pMore )
      FoldTree( numbers, tree->pMore );
}

void Shuffle( int *numbers )
{
	PHOLDER tree;
   int n;
	tree = NULL;
	nHolders = 0;
   nNumber = 0;
   for( n = 0; n < 75; n++ )
		tree = sort( tree, numbers[n], rand() );
   FoldTree( numbers, tree );
}

static int work_nums[75];

void DrawRandomNumbers2( void )
{
	int n;
	if( work_nums[1] != 1 )
	{
		for( n = 1; n <= 75; n++ )
		{
         work_nums[n-1] = n;
		}
	}
	Shuffle( work_nums );

	for( n = 0; n < balls; n++ )
	{
      nums_called[work_nums[n]-1]++;
		nums[n] = work_nums[n];
	}
	if( calls )
	{
		fprintf( calls, "%d %d %d %d"
				 , day
				 , session
				 , game
				 , hall );
		for( n = 0; n < balls; n++ )
			fprintf( calls, " %d", nums[n] );
		fprintf( calls, "\n" );
	}
}

long long dollars( long long pot )
{
   return pot / 80000L;
}

long cents( long long pot )
{
	if( pot < 0 )
      return ( (-pot) / 800 ) % 100;
   return ( (pot) / 800 ) % 100;
}


void PrintJackpots( void )
{
	int n;
	fprintf( pots, "Day %d Jackpots: ", day );
	for( n = 0; n < 8; n++ )
	{
		fprintf( pots, "$%Ld.%02ld %d "
				 , dollars(jackpots[n])
				 , cents(jackpots[n])
				 , hardways[n]
				 );
	}
   fprintf( pots, "\n" );
}

int can_bingo( void )
{
	int n;
	int cols[5], bingo_row;
	int result;
	//bingo_col = BALL_B|BALL_I|BALL_G|BALL_O; // all balls or'd
   cols[0] = 0;
   cols[1] = 0;
   cols[2] = 0;
   cols[3] = 0;
   cols[4] = 0;
	bingo_row = 0x1f; 

	for( n = 0; n < balls; n++ )
	{
		if( nums[n] <= 15 ) // is B
		{
			if( ++cols[0] >= 5 ) return TRUE;
			bingo_row &= ~BALL_B;
		}

		if( nums[n] > 15 && nums[n] <= 30 ) // is I
		{
			if( ++cols[1] >= 5 ) return TRUE;
			bingo_row &= ~BALL_I;
		}

		if( nums[n] > 30 && nums[n] <= 45 ) // is N
		{
			//if( ++cols[2] >= 5 ) return TRUE;
			bingo_row &= ~BALL_N;
		}

		if( nums[n] > 45 && nums[n] <= 60 ) // is G
		{
			if( ++cols[3] >= 5 ) return TRUE;
			bingo_row &= ~BALL_G;
		}

		if( nums[n] > 60 ) // is O
		{
			if( ++cols[4] >= 5 ) return TRUE;
			bingo_row &= ~BALL_O;
		}

		if( !bingo_row )
			return TRUE;

	}
	return FALSE;
}

// n == jackpot to pay
void do_payout( int n, int won_in )
{
	long long payout = jackpots[n];
	if( payout < (minimum_jackpot * 8) )
		payout = (minimum_jackpot * 8);
	payout = payout - (payout % 80000);

	if( won_in < last_won_in[n] )
	{
		if( last_won_in[n] != 75 )
		{
         // correction record...
         payout = 0;
		}
      last_won_in[n] = won_in;
	}
	else
      return; // don't even attempt payout...
	hardways[n]++;
	fprintf( pays, "%d %d %d %d card %d wonin %d paid %d $%Ld.%02ld\n"
			 , day
			 , session
			 , game
			 , hall
			 , current_card
			 , won_in+1
			 , n
			 , dollars(payout)
			 , cents(payout) );

 	total_payout += payout;
	jackpots[n] -= payout;

   jackpots_paid++;
   return;
}

void check_hardway( int card[5][5] )
{
	int n, i, row, col, ball;
	static int hardway_win[8];
	for( n = 0; n < 8; n++ )
      hardway_win[n] = 5; // decrement with each ball which succeeds
	for( ball = 0; ball < balls; ball++ )
	{
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
				{
					if( card[row][i] == nums[ball] )
					{
						if( !(--hardway_win[n]) )
						{
							do_payout( n, ball );
							return;
						}
                  break;
					}
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
				{
					if( card[i][col] == nums[ball] )
					{
						if( !(--hardway_win[n]) )
						{
							do_payout( n, ball );
							return;
						}
                  break;
					}
				}
				break;
			}
		}
	}
}

void load_cards( void )
{
	FILE *in = fopen( cardfile, "rb" );
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
      fclose( in );
	}
}

PTRSZVAL CPROC SetDays( PTRSZVAL psv, _64 num )
{
   days = num;
   return psv;
}

PTRSZVAL CPROC SetBalls( PTRSZVAL psv, _64 num )
{
	if( num > 75 )
		num = 75;
	if( num < 1 )
      num = 1;
   balls = num;
   return psv;
}

PTRSZVAL CPROC SetSessions( PTRSZVAL psv, _64 num )
{
   sessions = num;
   return psv;
}

PTRSZVAL CPROC SetGames( PTRSZVAL psv, _64 num )
{
   games = num;
   return psv;
}

PTRSZVAL CPROC SetHalls( PTRSZVAL psv, _64 num )
{
   halls = num;
   return psv;
}

PTRSZVAL CPROC SetPlayers( PTRSZVAL psv, _64 num )
{
   players = num;
   return psv;
}

PTRSZVAL CPROC SetAccrual( PTRSZVAL psv, _64 num )
{
	accrual = num;
   return psv;
}

PTRSZVAL CPROC SetMinimum( PTRSZVAL psv, _64 num )
{
	minimum_jackpot = num;
   return psv;
}

PTRSZVAL CPROC SetCardFile( PTRSZVAL psv, char *word )
{
   strcpy( cardfile, word );
   return psv;
}

PTRSZVAL CPROC SetRandomMethod( PTRSZVAL psv, _64 val )
{
	switch( (int)val )
	{
	case 0:
		DrawRandomNumbers = DrawRandomNumbers0;
		break;
	default:
		printf( "Invalid random method (0-2) defaulting to 0.\n" );
		DrawRandomNumbers = DrawRandomNumbers0;
		break;
	case 1:
		DrawRandomNumbers = DrawRandomNumbers1;
		break;
	case 2:
		DrawRandomNumbers = DrawRandomNumbers2;
		break;
	}
	return psv;
}

PTRSZVAL CPROC SetSeed( PTRSZVAL psv, _64 val )
{
	srand( (int)val );
	return psv;
}

void ReadConfig( void )
{
	PCONFIG_HANDLER pch;
	pch = CreateConfigurationEvaluator();
   AddConfigurationMethod( pch, "days %i", SetDays );
   AddConfigurationMethod( pch, "balls %i", SetBalls );
   AddConfigurationMethod( pch, "sessions %i", SetSessions );
   AddConfigurationMethod( pch, "games %i", SetGames );
   AddConfigurationMethod( pch, "halls %i", SetHalls );
   AddConfigurationMethod( pch, "players %i", SetPlayers );
	AddConfigurationMethod( pch, "accrual %i", SetAccrual );
	AddConfigurationMethod( pch, "minimum %i", SetMinimum );
	AddConfigurationMethod( pch, "cardfile %m", SetCardFile );
	AddConfigurationMethod( pch, "random method %i", SetRandomMethod );
	AddConfigurationMethod( pch, "seed %i", SetSeed );
   ProcessConfigurationFile( pch, "odds.config", 0 );
}

int main( int argc, char **argv )
{
	int n = 0;
   int append = 0;
	srand( time( NULL ) );
   ReadConfig();

  	calls = fopen( "calls.log", "wt" );
  	pays = fopen( "pays.log", "wt" );
	pots = fopen( "pots.log", "wt" );
   ballstats = fopen( "balls.log", "wt" );
	if( !cardfile[0] )
      strcpy( cardfile, "f126-2.dat" );
	load_cards();
	fprintf( stderr, "Loaded %d cards from %s\n", card_count, cardfile );
	printf( "Playing for %d days.\n", days );
   printf( "%d games per session, %d sessions\n", games, sessions );
	printf( "%d cards in %d halls.\n", players, halls );
	printf( "Each card accrues $%ld.%d cents.\n"
			   , (accrual / 100L )
			   , (accrual % 100L ) );
	{
		int n;
		for( n = 0; n < 8; n++ )
		{
         last_won_in[n] = 75;
		}
	}
#define Loop(name) for( name = 0; name < name##s; name++ )
   Loop(day)
	{
		int accumulator = 0;
      Loop(session)
		{
         Loop(game)
			{
            Loop(hall)
				{
               DrawRandomNumbers();
  					total++; // total number
  					if( can_bingo() )
					{
                  checked++; // count of draws that are even remotely possible.
                  //printf( "possible...\n" );
						Loop(player)
						{
                     cards_played++;
							// add hundreths of penny per card.
							accumulator += accrual;
                     current_card = ( session * games * halls * players +
															   game * halls * players +
															   hall * players +
															   player ) % card_count;
							check_hardway( allcards[ current_card ] );
						}
					}
					else
					{
						accumulator += 70 * players;
                  cards_played += players;
					}
				}
			}
		}
		//printf( "Cards played: %d\n", cards_played );
		if( !quiet )
		{
         fprintf( pots, "0 " );
			PrintJackpots();
		}
		for( n = 0; n < 8; n++ )
		{
			// nature of the jackpot figure assumes divide by 8
         // so the accumulator can be added as is.
			//  jackpots[n] += accumulator / 8;
			//   then jackpots[n] += accumulator; if jackpots[n]/8 is shown
			jackpots[n] += accumulator;
			if( jackpots[n] > highest_jackpot )
			{
				highest_jackpot = jackpots[n];
            highest_day = day;
			}
         last_won_in[n] = 75; // reset last wins...
		}
		if( !quiet )
		{
         fprintf( pots, "1 " );
			PrintJackpots();
		}
	}
	printf( "Played %Ld total cards\n", cards_played );
	printf( "Played %Ld ball calls\n", total );
	if( checked )
	{
		long x = 0;
		int i;
		for( i = 0; i < 8; i++ )
         x += hardways[i];
		printf( "%Ld calls were possible of %Ld (1:%Ld)  1:%Ld won\n"
				, checked
				, total
				, total/checked
				, !x?0:total/x
				);

	}
	if( jackpots_paid )
	{
	printf( "Jackpots paid: %d Total amount: $%Ld.%02ld Average: $%Ld.%02ld\n"
			, jackpots_paid
			, dollars( total_payout )
         , cents( total_payout )
			, dollars( (total_payout / jackpots_paid ) )
         , cents( (total_payout / jackpots_paid ) )
			);
	printf( "Highest jackpot: $%Ld.%02ld\n"
			, dollars(highest_jackpot )
			, cents(highest_jackpot )
			);
   printf( "Paid a jackpot every %g days\n", (double)days / (double)jackpots_paid );
	printf( "Paid a jackpot every %15.15g cards\n", (double)cards_played / (double)jackpots_paid );
	}
	{
		int n;
		int ranges[5]= { 0,0,0,0,0};
		for( n = 0; n < 75; n++ )
		{
			if( n < 15 )
				ranges[0]+=nums_called[n];
         else if( n < 30 )
				ranges[1]+=nums_called[n];
         else if( n < 45 )
				ranges[2]+=nums_called[n];
         else if( n < 60 )
				ranges[3]+=nums_called[n];
         else 
				ranges[4]+=nums_called[n];
         fprintf( ballstats, "%d - %d\n", n+1, nums_called[n] );
		}
		fprintf( ballstats, "\n\n\n\n\n\n\n" );
		for( n = 0; n < 5; n++ )
		{
         fprintf( ballstats, "%c - %d\n", "BINGO"[n], ranges[n] );
		}
	}


   fflush( stdout );
   return 0;
}


