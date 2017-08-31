//登录页js
$( function ()
{
    //进入之后检测
    if ( $( '#txtName' ).val() != '' )
    {
        $( '.alertUserName' ).hide();
    }
    if ( $( '#txtPassWord' ).val() != '' )
    {
        $( '.alertPassWord' ).hide();
    }


    //输入用户名

    $( '#txtName' ).on( 'focus blur', function (e)
    {
        if ( e.type == 'focus' )
        {
            $( '.alertUserName' ).hide();
        }
        else if(e.type=='blur')
        {
            if ( $( this ).val() == '' )
            {
                $( '.alertUserName' ).show();
            }
        }
    } );

    //输入密码
    $( '#txtPassWord' ).on( 'focus blur', function ( e )
    {
        if ( e.type == 'focus' )
        {
            $( '.alertPassWord' ).hide();
        }
        else if ( e.type == 'blur' )
        {
            if ( $( this ).val() == '' )
            {
                $( '.alertPassWord' ).show();
            }
        }
    } );


} );