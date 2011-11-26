<?php
//----------------------------------------------------
// The use of the data sent from the Javascript side is enabled.
//----------------------------------------------------
$data         = array();

$db_table     = sqlite_escape_string($_GET['db_table']);
$q_word       = sqlite_escape_string($_GET['q_word']);
$page_num     = sqlite_escape_string($_GET['page_num']);
$per_page     = sqlite_escape_string($_GET['per_page']);
$field        = sqlite_escape_string($_GET['field']);
$show_field   = sqlite_escape_string($_GET['show_field']);
$hide_field   = sqlite_escape_string($_GET['hide_field']);
$select_field = sqlite_escape_string($_GET['select_field']);
$order_field  = sqlite_escape_string($_GET['order_field']);
$primary_key  = sqlite_escape_string($_GET['primary_key']);
$order_by     = sqlite_escape_string($_GET['order_by']);

$offset       = ($page_num - 1) * $per_page;
$show_field   = ($show_field)
	? explode(',',$show_field)
	: array(false);
$hide_field   = explode(',',$hide_field);


//----------------------------------------------------
// connect data base
//----------------------------------------------------
$db = sqlite_open('../SQLite2/test.sqlite','0600');


//----------------------------------------------------
// get autocomplete candidate
//----------------------------------------------------
$query = "

	SELECT   $select_field
	FROM     $db_table
	WHERE    $field LIKE '%$q_word%'
	ORDER BY (
		CASE
			WHEN $order_field LIKE '$q_word'
			THEN 0
			WHEN $order_field LIKE '$q_word%'
			THEN 1
			ELSE 2
		END
	), $order_field $order_by
	LIMIT    $per_page
	OFFSET   $offset

";
$rows  = sqlite_query($db,$query);

$data['cnt_page'] = 0;
$attached_cnt = 0;
while ($row = sqlite_fetch_array($rows,SQLITE_ASSOC))
{
	$data['cnt_page'] ++;
	foreach($row as $key => $value){

		// for "select_only" option
		if($key == $primary_key){
			$data['primary_key'][] = $value;
		}

		// get the value for autocomplete candidate
		if($key == $field){
			$data['candidate'][] = $value;

		} else {

			// for Sub-info
			if(!in_array($key, $hide_field)){

				// It non-displays it in the exclusion column when not corresponding
				// to the display column though it doesn't correspond.
				// However, it doesn't become non-display when there is "*"
				// in the display column.
				if(
					$show_field[0] !== false
					&& !in_array('*', $show_field)
					&& !in_array($key, $show_field)
				){
					continue;
				}

				$data['attached'][$attached_cnt][] = array(
					0 => $key,
					1 => $value
				);
			}
		}
	}
	$attached_cnt++;
}


//----------------------------------------------------
// get the entire number
//----------------------------------------------------
$query = "
	SELECT   $field
	FROM     $db_table
	WHERE    $field LIKE '%$q_word%'
";
$data['cnt'] = sqlite_num_rows( sqlite_query($db,$query) );

echo json_encode($data);


//----------------------------------------------------
// End
//----------------------------------------------------
// cut the connection with the data base
sqlite_close($db);

?>
