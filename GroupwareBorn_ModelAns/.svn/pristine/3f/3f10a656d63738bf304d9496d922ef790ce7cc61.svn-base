<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>施設一覧</title>
<meta charset="UTF-8">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<script type="text/javascript">
	function kakunin() {
		window.open(".", "サブ検索画面", "width=300,height=200,scrollbars=yes");
	}
</script>
</head>
<body>
	<div id="base">
		<jsp:include page="/WEB-INF/views/header/header.jsp" flush="true" />
		<div id="contents">
			<div id="view-title">施設一覧</div>
			<!--
            <ul class="msgs">
                <li>エラーメッセージ表示エリア</li>
            </ul>
             -->
			<p id="contents-title">施設を選択してください。</p>

			<!-- formタグ内で使用する場合 -->
			<form:form modelAttribute="facilityListForm" action="/facility/detail/${department.deptno}"
				method="post">

				<form:select path="facilityInfoType" multiple="false"
					onchange="kakunin()" selected="false">
					<c:forEach items="${facilityListForm.facilityMapTypeList}"
						var="facilityInfo" varStatus="loop">
						<c:choose>
							<c:when test="${facilityInfo.key == '0' }">
								<form:option label="${facilityInfo.value}"
									value="${facilityInfo.key}" selected="selected" />
							</c:when>
							<c:otherwise>
								<form:option label="${facilityInfo.value}"
									value="${facilityInfo.key}" />
							</c:otherwise>
						</c:choose>
					</c:forEach>
				</form:select>



				<c:forEach var="facilityInfo" items="${facilityListForm.facilltyButtonInfoList}" varStatus="facilltyButtonInfoStatus">
					<c:if test="${facilltyButtonInfoStatus.first}">
						<ul id="facility">
					</c:if>
					<li class="facility-list">
						<form:button name="selectedFacility" value="${facilityInfo.id}">${facilityInfo.name}:${facilityInfo.capacity}</form:button>
						</li>
					<c:if test="${facilltyButtonInfoStatus.last}">
						</ul>
					</c:if>
				</c:forEach>

			</form:form>
		</div>
		<div id="return-display">
			<a href="menu.html">前のページに戻る</a>
		</div>
		<jsp:include page="/WEB-INF/views/footer/footer.jsp" flush="true" />

	</div>
</body>
</html>