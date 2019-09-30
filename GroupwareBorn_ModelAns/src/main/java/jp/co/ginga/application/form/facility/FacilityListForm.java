package jp.co.ginga.application.form.facility;

import java.io.Serializable;
import java.util.List;

public class FacilityListForm implements Serializable{


	/**
	 * 施設一覧情報
	 */
	private List<FacilityForm> facilityList;

	/**
	 * @return facilityList
	 */
	public List<FacilityForm> getFacilityList() {
		return facilityList;
	}

	public void setFacilityList(List<FacilityForm> facilityFormList) {
		this.facilityList =facilityFormList;
	}

}
