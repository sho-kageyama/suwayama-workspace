package jp.co.ginga.domain.repository;

import java.util.List;

import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Select;
import org.springframework.stereotype.Repository;

import jp.co.ginga.domain.entity.FacilityTypeEntity;

/**
 * 施設種別テーブルRepository
 * @author yoshi
 *
 */
@Mapper
@Repository
public interface FacilityTypeRepository {

	/**
	 * 施設種別全件検索処理
	 *
	 * @return
	 */

	@Select("select id,name,insert_date as insertDate,update_date as updateDate,user_id as userId from facility_type")
	public List<FacilityTypeEntity> findAll();

	@Select("select name from facility_type where id = #{id}")
	public String findTypeName(int id);
}
