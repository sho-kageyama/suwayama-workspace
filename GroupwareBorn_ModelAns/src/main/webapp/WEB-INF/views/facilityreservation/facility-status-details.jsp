<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>予約状況</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">予約状況詳細</div>

			<spring:eval var="accountSessionForm" expression="@accountSessionForm"/>
			<input type="hidden" class="permission-level" value="${accountSessionForm.permissionLevel}"/>
			<input type="hidden" class="accountName" value="${accountSessionForm.accountName}"/>
			<input type="hidden" id="facilityId" value="${calendarListForm.facility.id}"/>

			<div id="auth-check"></div>
			<p id="contents-title">${calendarListForm.facility.name}</p>
			<div id="calender-menu">
				<input id="prevmonth" type="button" value="前月">
				<a id="day-info" class="${calendarListForm.year}-${calendarListForm.month}">
					${calendarListForm.year}年${calendarListForm.month}月
				</a>
				<input id="nextmonth" type="button" value="次月">
			</div>

			<table id="calender">
				<thead>
					<tr>
						<th class="calender-th">月</th>
						<th class="calender-th">火</th>
						<th class="calender-th">水</th>
						<th class="calender-th">木</th>
						<th class="calender-th">金</th>
						<th class="holiday calender-th">土</th>
						<th class="holiday calender-th">日</th>
					</tr>
				</thead>
				<tbody>
				<c:forEach var="calendar" items="${calendarListForm.calendar}" varStatus="loop">
					<c:choose>
						<c:when test="${calendar.day == 0}">
							<td></td>
						</c:when>
						<c:otherwise>
							<td><p>${calendar.day}</p>
								<c:forEach var="reservation" items="${calendar.reservationList}">
									<p id="reservation_Detail">
										<input type="hidden" id="reservationId" value="${reservation.id}" />
										<a id="${reservation.id}" class="${reservation.userId}" style="text-decoration:underline;">
										${reservation.startTime}〜${reservation.endTime}
										<br>
										${reservation.userId}
										</a>
									</p>
								</c:forEach>
								<input type="image" src="/img/add.png" id="add" alt="新規予約" value="${calendar.day}"/>
							</td>
						</c:otherwise>
					</c:choose>
					<c:if test="${!loop.first and loop.count % 7 == 0}">
						<tr></tr>
					</c:if>
				</c:forEach>
				</tbody>
			</table>
		</div>
		<div id="return-display">
			<a href="/menu">前のページに戻る</a>
		</div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />
	</div>

	<script>
	$(window).on('load', function(){
		add();
		check();
		$('#nextmonth, #prevmonth').click(function(){
			var facilityId = $('input#facilityId').val();
			var yearmonth = $('a#day-info').attr('class').split('-');

			var calendarForm = {
				'year':yearmonth[0],
				'month':yearmonth[1]
			};

			$.when(
			$.ajax({
				url : '/facility-reservations/'+this.id+'/'+facilityId,
				type : 'post',
				data : JSON.stringify(calendarForm),
				dataType : 'json',
				contentType : 'application/json ; charset=UTF-8'
			}).done(function(data,status,jqXHR){
				

				$('a#day-info').text(data.year+'年'+data.month+'月');
				$('a#day-info').attr('class', data.year+'-'+data.month);
				$('table tbody').empty();
				
				
				for(var i in data.calendar){
					if(data.calendar[i].day == 0){
						$('table tbody').append('<td></td>');
					} else {
						var cell = '<td><p>'+data.calendar[i].day+'</p>';

						for(var j in data.calendar[i].reservationList){
							var reservation = data.calendar[i].reservationList;

							cell += '<p id="reservation_Detail"><a id="'+reservation[j].id+'" class="'+reservation[j].userId+'" '
								  + 'style="text-decoration:underline;">'
								  + ''+reservation[j].startTime+'〜'+reservation[j].endTime+''
								  + '<br>'+reservation[j].userId+'</a></p>';
						}

						cell += '<input id="add" type="image" src="/img/add.png" alt="新規予約" '
							  + 'value="'+data.calendar[i].day+'" ></td>'

						$('table tbody').append(cell);
					}

					var day = Number(i) + 1;

					if(day % 7 == 0){
						$('table tbody').append('<tr></tr>');
					}
				}
			}).fail(function(jqXHR,status,errorThrown){
				alert(jqXHR.status);
			})
		
			).done(function(){
				add();
				check();
			});
		});

		

		
	});
	
	function add(){
	$('input#add').click(function(){
		var day = $(this).val();
		var yearmonth = $('a#day-info').attr('class');
		var facilityId = $('input#facilityId').val();
		location.href = '/facility-reservations/'+facilityId+'/add/'+yearmonth+'-'+day;
	});
	}
	
	function check(){
	$('p#reservation_Detail').on('click', function(){
		var auth = $('input.permission-level').val();
		var reserver = $(this).find('a').attr('class');
		var user = $('input.accountName').val();
		var facilityId = $('input#facilityId').val();
		var reservationId =  $(this).find('a').attr('id');

		if(auth == 1 || reserver === user){
			location.href = '/facility-reservations/'+facilityId+'/'+reservationId;
		} else {
			$('#auth-check').empty();
			$("#auth-check").append('<p id="errors" style="color:red;">予約情報の編集権限がありません</p>');
			Obj = new Object();
			Obj.duration = 1500;
			Obj.complete = function(){
				$('#errors').remove();
			}
			$("#errors").fadeOut(Obj);
		}
	});
	}
	</script>
</body>
</html>