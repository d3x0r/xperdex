



int main( void )
{
	CTEXTSTR cmd = "SELECT *,count(*)/84,sum(points) as total FROM called_game_player_pack_status"
		" where pack_set_id > 0"
		" group by card,pack_set_id,session,bingoday"
		" order by bingoday,session,card,pack_set_id";


   /*
   select called_game_id,card,pack_set_id,session,bingoday,max(total_points) from
(SELECT *,count(*)/84,sum(points) as total_points FROM called_game_player_pack_status
where pack_set_id > 0
group by card,pack_set_id,session,bingoday
order by bingoday,session,card,pack_set_id) as x
group by bingoday,session,card
     */


   /*
   insert into called_game_player_rank(called_game_id,card,pack_set_id,session,bingoday,total_points ) select called_game_id,card,pack_set_id,session,bingoday,max(total_points) as total_points from
(SELECT *,count(*)/84,sum(points) as total_points FROM called_game_player_pack_status
where pack_set_id > 0
group by card,pack_set_id,session,bingoday
order by bingoday,session,card,pack_set_id) as x
group by bingoday,session,card
*/

}
