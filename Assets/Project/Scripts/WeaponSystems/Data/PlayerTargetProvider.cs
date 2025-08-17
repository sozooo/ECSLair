using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.WeaponSystems.Components;
using UnityEngine;

namespace Project.Scripts.WeaponSystems.Data
{
    public class PlayerTargetProvider : ITargetProvider
    {
        private readonly ScanData _scanData;
        private readonly Collider2D[] _overlapTargets;
        
        public PlayerTargetProvider(CancellationToken token, ScanData data)
        {
            _scanData = data;
            _overlapTargets = new Collider2D[_scanData.MaxTargetCount];
            
            ScanForTarget(token).Forget();
        }

        public Transform Target { get; private set; }

        private async UniTask ScanForTarget(CancellationToken token)
        {
            await UniTask.WaitForSeconds(1, cancellationToken: token);
            
            int count = Physics2D.OverlapCircleNonAlloc(
                _scanData.Center.position, 
                _scanData.Radius, 
                _overlapTargets, 
                _scanData.LayerMask);

            List<Collider2D> sortedTargets = _overlapTargets
                .Take(count)
                .ToList()
                .OrderBy(target => (target.transform.position - _scanData.Center.position).sqrMagnitude)
                .ToList();
            
            Target = sortedTargets[0].transform;
        }

    }
}