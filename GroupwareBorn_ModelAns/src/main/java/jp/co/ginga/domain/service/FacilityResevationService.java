package jp.co.ginga.domain.service;

import java.util.List;

import jp.co.ginga.application.form.facilityreservation.ReservationDetailForm;
import jp.co.ginga.domain.entity.FacilityReservationEntity;

public interface FacilityResevationService {

	/**
	 * 施設予約一覧情報取得
	 */
	public List<ReservationDetailForm> getFacilityReservationList(int facilityId, int year, int month);

	/**
	 * 施設予約情報取得
	 */
	public FacilityReservationEntity getFacilityReservationById(int id);

	/**
	 * 施設新規予約
	 */
	public int AddReservation(FacilityReservationEntity reservationEntity);

	/**
	 * 施設予約更新
	 */
	public int UpdateReservation(FacilityReservationEntity reservationEntity);

	/**
	 * 施設予約削除
	 */
	public int DeleteReservation(int id);

	/**
	 * 施設予約重複チェック
	 */
	public List<FacilityReservationEntity> checkDuplicate(FacilityReservationEntity reservationEntity);

}
