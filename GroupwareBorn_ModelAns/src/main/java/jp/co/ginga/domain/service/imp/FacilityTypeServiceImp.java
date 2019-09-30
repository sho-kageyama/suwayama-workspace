package jp.co.ginga.domain.service.imp;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import jp.co.ginga.domain.entity.FacilityTypeEntity;
import jp.co.ginga.domain.repository.FacilityTypeRepository;
import jp.co.ginga.domain.service.FacilityTypeService;

/**
 * 施設種別管理サービスクラス
 *
 * @author yoshi
 *
 */
@Service
@Transactional
public class FacilityTypeServiceImp implements FacilityTypeService {

	/**
	 * 施設種別リポジトリ
	 */
	@Autowired
	FacilityTypeRepository repoType;

	/**
	 * 施設種別情報リスト取得処理
	 */
	@Override
	public List<FacilityTypeEntity> getFacilityTypeList() {
		return repoType.findAll();
	}

	/**
	 * 指定した施設種別IDから施設種別名を取得する処理
	 */
	@Override
	public String getFacilityTypeName(int id) {
		return repoType.findTypeName(id);
	}

	/**
	 * @return repoUser
	 */
	public FacilityTypeRepository getRepoType() {
		return repoType;
	}

	/**
	 * @param repoUser セットする repoUser
	 */
	public void setRepoType(FacilityTypeRepository repoType) {
		this.repoType = repoType;
	}

}
